using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent; 
    private Animator anim;
    
    void Start()
    {
       anim = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(agent.velocity.magnitude);
        anim.SetFloat("Velocity", agent.velocity.magnitude / agent.speed);
    }
}
