using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_behaviour : MonoBehaviour
{
    [SerializeField] private float spring_value = 500f;
    [SerializeField] private float damper_value = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        SpringJoint[] springs = GetComponentsInChildren<SpringJoint>();

        for (int i = 0; i < springs.Length; i++)
        {
            springs[i].spring = spring_value;
            springs[i].damper = damper_value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
