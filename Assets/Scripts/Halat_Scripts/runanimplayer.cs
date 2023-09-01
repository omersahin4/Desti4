using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runanimplayer : MonoBehaviour
{
    public bool running = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            running = !running;
            animator.SetBool("running", running);
        }
    }
}
