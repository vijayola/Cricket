using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class look_at_ball : MonoBehaviour
{
    //[SerializeField] private ball_throw ball_throw;
    
    private MultiAimConstraint multiAimConstraint;
    private RigBuilder rigBuilder;
    // Start is called before the first frame update

    void OnEnable()
    {
        ball_throw.OnBallSpawned += Look_at_Ball_constraint;
    }
    void Start()
    {
        multiAimConstraint = GetComponent<MultiAimConstraint>();
        rigBuilder = GetComponentInParent<RigBuilder>();
    }

    void Look_at_Ball_constraint(GameObject ball)
    {
        Debug.Log("Look_at_Ball_constraint called !!");
        if (ball != null && multiAimConstraint != null)
        {
            var sources = multiAimConstraint.data.sourceObjects;
            sources.Clear();
            // Add the new source
            WeightedTransform weightedSource_ball = new WeightedTransform(ball.transform, 1f); 
            Debug.Log("new weighted Source : "+ weightedSource_ball);
            
            sources.Add(weightedSource_ball);

            multiAimConstraint.data.sourceObjects = sources;
            
            if (rigBuilder != null)
            {
                rigBuilder.Build(); // Optional but can help refresh constraints
            }
            
            Debug.Log("MultiAimConstraint now looking at: " + multiAimConstraint.data.sourceObjects[0].transform.name);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
