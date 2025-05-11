using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class player_animation : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        bool is_hitting = animator.GetBool("isHitting");
        bool hit_pressed = Input.GetKeyDown(KeyCode.Space);
        
        //UnityEngine.Debug.Log("isHitting: " + is_hitting);
        
        if (hit_pressed && (is_hitting == false))
        {
            animator.SetBool("isHitting", true);
        }

        if (!hit_pressed && (is_hitting == true))
        {
            animator.SetBool("isHitting", false);
        }
    }
}
