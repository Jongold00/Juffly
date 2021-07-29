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

    [SerializeField]
    private Animator anim;

    int lastDirPressed = 3;

    public Vector2Int inputVector = new Vector2Int(0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        UpdateMovement(inputVector);
        SetAnimRunState();
        
    }

    void HandleInput()
    {
        Vector2Int ret = new Vector2Int(0, 0);
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



        if (Input.GetKeyDown(KeyCode.W))
        {
            lastDirPressed = 1;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            lastDirPressed = 2;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            lastDirPressed = 3;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            lastDirPressed = 4;
        }

        inputVector = ret;

        if ((Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.D)) 
            && (inputVector.x != 0 || inputVector.y != 0))    // handling anim states for if a movement button is released but others are still held
        {
            switch (inputVector.y)
            {
                case 1:
                    print("up");
                    lastDirPressed = 1;
                    break;
                case -1:
                    print("down");
                    lastDirPressed = 3;
                    break;
                case 0:
                    break;
            }
            switch (inputVector.x)
            {
                case -1:
                    print("left");
                    lastDirPressed = 2;
                    break;
                case 1:
                    print("right");
                    lastDirPressed = 4;
                    break;
                case 0:
                    break;
            }
        }


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

    void SetAnimRunState()
    {
        anim.SetFloat("speed", rb2d.velocity.magnitude);
        anim.SetInteger("dirX", inputVector.x);
        anim.SetInteger("dirY", inputVector.y);
        anim.SetInteger("lastDir", lastDirPressed);

    }
}
