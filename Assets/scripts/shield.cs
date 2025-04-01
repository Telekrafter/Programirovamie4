using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    private float force = 150f;
    private float pushForce = 70f;
    private float verticalForceMultiplier = 0.5f;
    [SerializeField] private ForceMode forceMode = ForceMode.Impulse;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.attachedRigidbody) return; 
        Rigidbody rb = other.attachedRigidbody;

        impulse(rb);

    }
    private void impulse(Rigidbody rb)
    {
        rb.velocity = Vector3.zero;
        Vector3 direction = rb.position - transform.position;
        Vector3 horisontalDirection =  new Vector3(direction.x, 0, direction.z).normalized;
        Vector3 finalDirection = (horisontalDirection + Vector3.up * verticalForceMultiplier).normalized;
        rb.AddForce(finalDirection * pushForce, forceMode);
        

    }


}
