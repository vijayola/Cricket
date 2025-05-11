using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_throw : MonoBehaviour
{
    private Transform release_point;
    
    [SerializeField] private GameObject ballPrefab;
    
    [SerializeField] private float throw_force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            
            rb.AddForce(-transform.forward * throw_force, ForceMode.Impulse);
            
            Destroy(ball, 5f);
        }
    }
}
