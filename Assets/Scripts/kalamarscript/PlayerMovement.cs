using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    public Animator animator;

    // private Rigidbody2D rb;
    // private Vector2 movement;

    public Joystick jy;

    float vertical, horizontal;

    void Start()
    {
       // rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       // movement.x = Input.GetAxis("Horizontal");
       // movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        vertical = jy.Vertical;
        horizontal = jy.Horizontal;
        if (vertical != 0 || horizontal != 0)
        {
           // transform.up = new Vector3(horizontal * moveSpeed, vertical * moveSpeed, 0);
            transform.Translate(new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime, Space.World);
            animator.SetBool("running", true);
        }
        else
        {
            // Karakter durduðunda sabit durma animasyonunu etkinleþtir
            animator.SetBool("running", false);
        }
        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
