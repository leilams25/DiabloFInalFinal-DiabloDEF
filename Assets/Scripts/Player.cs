using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Transform ultimoClick;
    private Camera cam;
    private NavMeshAgent agent;
  
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();

    }

   
    void Update()
    {
       Movimiento();
        ComprobarInteraccion();

    }

   

    private void Movimiento()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {

                agent.SetDestination(hitInfo.point);


                ultimoClick = hitInfo.transform;
            }


        }
    }
    private void ComprobarInteraccion()
    {
        if(ultimoClick != null && ultimoClick.TryGetComponent(out NPC npc))
        { 
            agent.stoppingDistance = 2f;

            if( !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                npc.Interactuar( this.transform);
                ultimoClick = null;
            }
            else if (ultimoClick)
            {
               agent.stoppingDistance = 0f;
            }
        }
    }

}
