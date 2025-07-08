using UnityEngine;
using UnityEngine.InputSystem;

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

        //float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        //this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

}
