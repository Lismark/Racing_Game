using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float torqueForce;
    private Rigidbody2D rigidbody;
    [SerializeField] private string accelerate;
    [SerializeField] private string horizontal;
    private float currentSpeed;
    private Quaternion lastRotation;
    
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
        if (currentSpeed < 0.01f)
            rigidbody.angularVelocity = 0;
    }
    private void Moveing()
    {
        if (Input.GetButton(accelerate))
        {
            rigidbody.AddForce(transform.up * moveSpeed);
        }
            rigidbody.AddTorque((Input.GetAxis(horizontal) * -torqueForce) * (currentSpeed+0.1f));
    }
}
