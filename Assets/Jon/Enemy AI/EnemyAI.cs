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

    public Vector3 spawnPoint = new Vector3(0, 0, 0);

    public GameObject player;

    Vector3 playerPos;

    Rigidbody2D rb2d;

    public Vector3 currentDestination;

    public State currentState;



    public float wanderMoveSpeed;
    public float wanderDistance;

    float timeBeforeNewWander;

    public float fleeMoveSpeed;
    public float fleeDistance;






    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        rb2d = GetComponent<Rigidbody2D>();
        currentState = State.Fleeing;
        ChooseNewDestination();

        




    }

    private void Update()
    {
        playerPos = player.transform.position;

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
        if (ArrivedAtDestination())
        {
            timeBeforeNewWander -= Time.deltaTime;
            rb2d.velocity = new Vector2(0, 0);
            if (timeBeforeNewWander <= 0.0f)
            {
                timeBeforeNewWander = Random.Range(1, 3);
                ChooseNewDestination();
            }
        }
        else
        {
            rb2d.velocity = fleeMoveSpeed * ((currentDestination - transform.position).normalized);
            // 
        }
    }

    void UpdatePursuing()
    {
        if (ArrivedAtDestination())
        {
            timeBeforeNewWander -= Time.deltaTime;
            rb2d.velocity = new Vector2(0, 0);
            if (timeBeforeNewWander <= 0.0f)
            {
                timeBeforeNewWander = Random.Range(1, 3);
                ChooseNewDestination();
            }
        }
        else
        {
            rb2d.velocity = wanderMoveSpeed * (Mathf.Clamp(Vector3.Distance(transform.position, currentDestination) * wanderDistance / 2, 0.5f, 1.0f)) * ((currentDestination - transform.position).normalized);
            // 
        }
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
                Vector3 wanderDest;
                wanderDest = new Vector3(spawnPoint.x + Random.Range(wanderDistance * -1, wanderDistance), spawnPoint.y + Random.Range(wanderDistance * -1, wanderDistance));
                currentDestination = wanderDest;
                break;

            case State.Fleeing: // choose a random point away from player, slightly to a side at random
                Vector3 fleeDest;
                float angleFromPlayer = Mathf.Deg2Rad * Mathf.Atan((transform.position.y - playerPos.y)/(transform.position.x - playerPos.x));    // directional vector from player pointing at AI unit
                float alteredAngle = Mathf.Tan(angleFromPlayer + Random.Range(-20, 20));
                fleeDest = new Vector3(Mathf.Cos(alteredAngle), Mathf.Sin(alteredAngle), 0) * (Vector3.Distance(transform.position, playerPos) + fleeDistance);
                currentDestination = fleeDest;
                break;

        }

    }
}
