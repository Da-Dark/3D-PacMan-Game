using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;
    public Vector3 initialDirection;
    public LayerMask obstacleLayer;

    public new Rigidbody rigidbody {  get; private set; }
    public Vector3 direction {  get; private set; }
    public Vector3 nextDirection { get; private set; }
    public Vector3 startingPosition { get; private set; }

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.startingPosition = this.transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector3.zero;
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }

    public void Update()
    {
        if(this.nextDirection != Vector3.zero)
        {
            SetDirection(this.nextDirection);
        }
    }

    private void FixedUpdate()
    {
        Vector3 position = this.transform.position;
        Vector3 translation = this.direction * this.speed * this.speedMultiplier;

        this.rigidbody.MovePosition(position + translation);
    }

    public void SetDirection(Vector3 direction, bool forced = false)
    {
        if(forced || !Occupied(direction))
        {
            this.direction = direction;
            this.nextDirection = Vector3.zero;
        }
        else
        {
            this.nextDirection = direction;
        }
    }

    public bool Occupied(Vector3 direction)
    {
        RaycastHit hit = new RaycastHit();
        return Physics.BoxCast(
            this.transform.position,
            Vector3.one * 0.375f, // half the box size
            direction.normalized,
            out hit,
            Quaternion.identity,
            1.5f,
            this.obstacleLayer
        ) && hit.collider != null;
    }


}
