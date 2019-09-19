using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    private bool isMove = false;
    private bool isGrounded = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            isMove = true;
        else if (Input.GetMouseButtonUp(0))
            isMove = false;
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            if (!isGrounded)
            {
                rb.AddTorque(rotationSpeed * rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
                return;
            }

            rb.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) => isGrounded = true;
    private void OnCollisionExit2D(Collision2D collision) => isGrounded = false;

}
