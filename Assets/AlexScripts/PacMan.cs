using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectReference : MonoBehaviour
{
    public GameObject Player; // Assigned in Inspector
    private Pacman player;

    private void Start()
    {
        player = Player.GetComponent<Pacman>(); // get the Player script component
        if (player != null)
        {
            Debug.Log(Player.transform.position); // or player.transform.position
        }
        else
        {
            Debug.LogError("Player script not found on assigned GameObject!");
        }
    }
}
public class Pacman : MonoBehaviour
{
 

    public Movement movement {  get; private set; }
    private void Awake()
    {
        movement = GetComponent<Movement>();
    }
    private void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard.wKey.wasPressedThisFrame || keyboard.upArrowKey.wasPressedThisFrame)
        {
            movement.SetDirection(Vector3.left);
        }
        else if (keyboard.sKey.wasPressedThisFrame || keyboard.downArrowKey.wasPressedThisFrame)
        {
            movement.SetDirection(Vector3.right);
        }
        else if (keyboard.aKey.wasPressedThisFrame || keyboard.leftArrowKey.wasPressedThisFrame)
        {
            movement.SetDirection(Vector3.back);
        }
        else if (keyboard.dKey.wasPressedThisFrame || keyboard.rightArrowKey.wasPressedThisFrame)
        {
            movement.SetDirection(Vector3.forward);
        }
    }

}
