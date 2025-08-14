using UnityEngine;

public class GhostFrightened : GhostBehavior
{
    public bool eaten { get; private set; }

    /*
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer blue;
    public SpriteRenderer white;
    */


    public override void Enable(float duration)
    {
        base.Enable(duration);

        /*
        this.body.enabled = false;
        this.eyes.enabled = false;
        this.blue.enabled = true;
        this.white.enabled = false;
        */

        Invoke(nameof(Flash), duration / 2.0f);

    }

    public override void Disable()
    {
        base.Disable();

        /*
        this.body.enabled = true;
        this.eyes.enabled = true;
        this.blue.enabled = false;
        this.white.enabled = false;
        */
    }
    private void Flash()
    {
        /*
        if (!this.eaten)
        {
            this.blue.enabled = false;
            this.white.enabled = false;
            this.white.GetComponent<AnimatedSprite>().Restart();
        }
        */
    }

    private void Eaten()
    {
        this.eaten = true;

        Vector3 position = this.ghost.home.inside.position;
        position.z = this.ghost.transform.position.z;
        this.ghost.transform.position = position;

        this.ghost.home.Enable(this.duration);

        /*
        this.body.enabled = false;
        this.eyes.enabled = true;
        this.blue.enabled = false;
        this.white.enabled = false;
        */
    }

    private void OnEnable()
    {
        this.ghost.movement.speedMultiplier = 0.5f;
        this.eaten = false;
    }

    private void OnDisable()
    {
        this.ghost.movement.speedMultiplier = 1.0f;
        this.eaten = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (this.enabled)
            {
                Eaten();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled)
        {
            Vector3 direction = Vector3.zero;
            float maxDistance = float.MinValue;

            foreach (Vector3 availableDirection in node.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
                float distance = (this.ghost.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = availableDirection;
                    maxDistance = distance;
                }
            }

            this.ghost.movement.SetDirection(direction);
        }
    }
}
