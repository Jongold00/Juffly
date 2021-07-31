using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum State
    {
        Wandering,
        Fleeing,
        Pursuing
    }

    public State currentState;

    public float wanderMoveSpeed;
    public float wanderDistance;

    public Vector3 spawnPoint = new Vector3(0, 0, 0);

    Rigidbody2D rb2d;
    public Vector3 currentDestination;
    float timeBeforeNewWander;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentState = State.Wandering;
        ChooseNewDestination();

    }

    private void Update()
    {


        switch (currentState)
        {
            case State.Wandering:
                UpdateWandering();
                break;
            case State.Fleeing:
                UpdateFleeing();
                break;
            case State.Pursuing:
                UpdatePursuing();
                break;
        }

    }

    void UpdateWandering()
    {
        
        if (ArrivedAtDestination())
        {
            timeBeforeNewWander -= Time.deltaTime;
            rb2d.velocity = new Vector2(0, 0);
            if (timeBeforeNewWander <= 0.0f)
            {
                timeBeforeNewWander = Random.Range(1,3);
                ChooseNewDestination();
            }
        }
        else
        {
            rb2d.velocity = wanderMoveSpeed * (Mathf.Clamp(Vector3.Distance(transform.position, currentDestination) * wanderDistance / 2, 0.5f, 1.0f)) * ((currentDestination - transform.position).normalized);
            // 
        }
    }

    void UpdateFleeing()
    {

    }

    void UpdatePursuing()
    {

    }

    bool ArrivedAtDestination()
    {
        if (Vector3.Distance(transform.position, currentDestination) < 0.2f)
        {
            return true;
        }
        return false;
    }

    void ChooseNewDestination()
    {
        switch(currentState)
        {
            case State.Wandering: // choose a random point that is in the circle of radius wanderDistance located at spawnPoint position
                currentDestination = new Vector3(spawnPoint.x + Random.Range(wanderDistance * -1, wanderDistance), spawnPoint.y + Random.Range(wanderDistance * -1, wanderDistance));   
                break;
        }
    }
}
