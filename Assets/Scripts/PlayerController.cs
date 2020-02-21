using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float torqueForce;
    private Rigidbody2D rigidbody;
    private string accelerate = "Vertical";
    private string horizontal = "Horizontal";
    private float currentSpeed;
    public const float minValue = 0.1f;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        currentSpeed = rigidbody.velocity.magnitude;
        Moveing();

    }

    private void Update()
    {
        if (currentSpeed < minValue)
        { 
            rigidbody.angularVelocity = 0;
        }
    }
    private void Moveing()
    {
        if (Input.GetAxis(accelerate) > 0)
            rigidbody.AddForce(transform.up * moveSpeed);
        if (Input.GetAxis(accelerate) < 0)
            rigidbody.AddForce(transform.up * -moveSpeed / 2);

        rigidbody.AddTorque((Input.GetAxis(horizontal) * -torqueForce) * (currentSpeed+minValue));
    }
}
