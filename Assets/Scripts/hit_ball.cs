using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_ball : MonoBehaviour
{
    [SerializeField] private float force_multiplier = 10f;

    private Vector3 dragStart;
    private Vector3 dragEnd;
    
    [SerializeField] private ball_throw ball_throw;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStart = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragEnd = Input.mousePosition;
            
            Vector3 dragVector = dragEnd - dragStart;
            
            Debug.Log("dragVerctor : " + dragVector);
            
            // Convert drag vector to world direction
            Vector3 worldDirection = new Vector3(dragVector.x, 0, dragVector.y).normalized;
            
            float forceMagnitude = dragVector.magnitude * force_multiplier;
            
            // get current thrown ball from "ball_throw" script
            GameObject ball = ball_throw.GetBall();

            if (ball != null)
            {
                ball.GetComponent<Rigidbody>().AddForce(worldDirection * forceMagnitude, ForceMode.Impulse);
            }
        }
        
    }
}
