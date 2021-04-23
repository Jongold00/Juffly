using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 0.01f;
    public float jumpConstant = 100f;

    [SerializeField]
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // this.gameObject.transform.Translate(new Vector3(0, 0, movementSpeed));
            _rb.AddForce(new Vector3(0, 0, movementSpeed));
        }

        if (Input.GetKey(KeyCode.A))
        {
            // this.gameObject.transform.Translate(new Vector3(-movementSpeed, 0, 0));
            gameObject.transform.Rotate(new Vector3(0, 0, -movementSpeed));

        }

        if (Input.GetKey(KeyCode.S))
        {
            // this.gameObject.transform.Translate(new Vector3(0, 0, -movementSpeed));
            _rb.AddForce(new Vector3(0, 0, -movementSpeed));

        }

        if (Input.GetKey(KeyCode.D))
        {
            // this.gameObject.transform.Translate(new Vector3(movementSpeed, 0, 0));
            gameObject.transform.Rotate(new Vector3(0, 0, movementSpeed));

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // this.gameObject.transform.Translate(new Vector3(0, movementSpeed, 0));
            _rb.AddForce(new Vector3(0, jumpConstant * movementSpeed, 0));


        }
    }
}
