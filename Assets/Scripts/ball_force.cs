using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_force : MonoBehaviour
{
    [SerializeField] private float force_magnitude = 10f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 direction = Vector3.right;
            rb.AddForce(direction * force_magnitude, ForceMode.Impulse);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 direction = Vector3.left;
            rb.AddForce(direction * force_magnitude, ForceMode.Impulse);
        }
    }
}
