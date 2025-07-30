using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public List<Vector3> availableDirections {  get; private set; }

    private void Start()
    {
        this.availableDirections = new List<Vector3>();

        CheckAvailableDirection(Vector3.forward);
        CheckAvailableDirection(Vector3.back);
        CheckAvailableDirection(Vector3.left);
        CheckAvailableDirection(Vector3.right);

    }

    private void CheckAvailableDirection(Vector3 direction)
    {
        RaycastHit hit;
        bool isBlocked = Physics.BoxCast(
            this.transform.position,
            Vector3.one * 0.375f, // half the box size
            direction.normalized,
            out hit,
            Quaternion.identity,
            1.5f,
            this.obstacleLayer
        );

        if (!isBlocked || hit.collider == null)
        {
            this.availableDirections.Add(direction);
        }
    }
   


}
