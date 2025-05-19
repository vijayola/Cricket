using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_throw : MonoBehaviour
{
    private Transform release_point;
    
    [SerializeField] private GameObject ballPrefab;
    
    private GameObject ball;
    
    [SerializeField] private float throw_force;
    // Start is called before the first frame update
    
    public static Action<GameObject> OnBallSpawned;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            
            // call delegate when new ball spawns
            Debug.Log("OnBallSpawned Invoked !!");
            OnBallSpawned?.Invoke(ball);
            
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            
            rb.AddForce(-transform.forward * throw_force, ForceMode.Impulse);
            
            Destroy(ball, 5f);
        }
    }

    public GameObject GetBall()
    {
        return ball;
    }
}
