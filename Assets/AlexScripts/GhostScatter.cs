 using UnityEngine;

public class GhostScatter : GhostBehavior
{
    private void OnDisable()
    {
        this.ghost.chase.Enable();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled && !this.ghost.frightened.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            Vector3 chosenDirection = node.availableDirections[index];

            if (node.availableDirections.Count > 1 && chosenDirection == -this.ghost.movement.direction)
            {
                index = (index + 1) % node.availableDirections.Count;
                chosenDirection = node.availableDirections[index];
            }

            this.ghost.movement.SetDirection(chosenDirection);
        }
    }
}
