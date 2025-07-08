using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int points = 10;

    protected virtual void Eat()
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.PelletEaten(this);
        }
        else
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Pellet triggered by: {other.gameObject.name}");

        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Eat();
        }
    }
}
