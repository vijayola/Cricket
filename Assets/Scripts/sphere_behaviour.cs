using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere_behaviour : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 direction = Vector3.up;
            rb.AddForce(direction * force_magnitude, ForceMode.Impulse);
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 direction = Vector3.down;
            rb.AddForce(direction * force_magnitude, ForceMode.Impulse);
        }
    }
}
