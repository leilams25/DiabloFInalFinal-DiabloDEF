using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
public class PlayerControlelr : MonoBehaviour
{
    const string IDLE = "Idle";
    const string WALK = "Walk";

    CustomeActions input;

    NavMeshAgent agent;
    Animator animator;

    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffects;
    [SerializeField] LayerMask clickableLayers;


    float lockRotationSpeed = 8f;





    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();


        input = new CustomeActions();
        AssignInputs();
    }


      void AssignInputs()
    {

        input.Main.Move.performed += ctx => ClickToMove();

    }


    void ClickToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))

        {
            agent.destination = hit.point;
            if (clickEffects != null)
            {

                Instantiate(clickEffects, hit.point += new Vector3(0, 0.1f, 0), clickEffects.transform.rotation);

            }


        }
    }


    private void OnEnable()
    {
        input.Enable();
    }


    private void OnDisable()
    {
        input.Disable();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
