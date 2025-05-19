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
    public static Action AllBallsDestroyed;
    
    // list to check ball count
    private List<GameObject> ball_count = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Ball Count : " + ball_count.Count);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            
            // add new ball to list
            ball_count.Add(ball);
            
            // call delegate when new ball spawns
            Debug.Log("OnBallSpawned Invoked !!");
            OnBallSpawned?.Invoke(ball);

            ball.AddComponent<ball_destroy_watcher>().Init(() =>
            {
                Debug.Log("AllBallsDestroyed Invoked !!");
                ball_count.RemoveAt(ball_count.Count - 1);
                
              //AllBallsDestroyed?.Invoke(); 
                if (ball_count.Count == 0)
                {
                    Debug.Log("OnBallDestroyed Invoked !!");
                    AllBallsDestroyed?.Invoke();
                }
            });
            
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
