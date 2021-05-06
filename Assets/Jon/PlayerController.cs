using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speedCo = 1f;

    //private float currentMoveX = 0;
    //private float currentMoveY = 0;
    [Range(0, 9), SerializeField]
    public float maxSpeed = 4f;

    [SerializeField]
    private Transform playerTrans;

    [SerializeField]
    private Rigidbody2D rb2d;

    private Vector2 inputVector = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputVector = HandleInput();
        UpdateMovement(inputVector);
        //print(rb2d.velocity);
    }

    Vector2 HandleInput()
    {
        Vector2 ret = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            ret.y += 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            ret.x -= 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            ret.y -= 1; 
        }

        if (Input.GetKey(KeyCode.D))
        {
            ret.x += 1;
        }
        return ret;


    }

    void UpdateMovement(Vector2 inp) 
    {
        Vector2 newForce = inp;
        rb2d.AddForce(CapSpeed(newForce) * speedCo);


    }

    Vector2 CapSpeed(Vector2 inp)
    {
        Vector2 ret = inp;
        if ((rb2d.velocity.x > maxSpeed && inp.x == 1) || (rb2d.velocity.x < -maxSpeed && inp.x == -1))
        {
            ret.x = 0;
        }

        if ((rb2d.velocity.y > maxSpeed && inp.y == 1) || (rb2d.velocity.y < -maxSpeed && inp.y == -1))
        {
            ret.y = 0;
        }
        

        return ret;
    }
}
