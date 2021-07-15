using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform playerTrans;

    // private Camera camera;

    private Vector3 bottomLeft;
    private Vector3 topRight;

    private float boundPadX = 1.0f; // offset from the side of the screen that the camera will start following at
    public float boundPadY = 1.0f;

    public float cameraMoveSpeed = 0.1f;
    private Vector2 playerCameraOffset = new Vector2(0, 0);
    private Vector3 playerOffset;
    // Update is called once per frame
    private void Start()
    {
        camera = GetComponent<Camera>();
        topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

        playerCameraOffset.x = (topRight.x - boundPadX);
        playerCameraOffset.y = (topRight.y - boundPadY);


    }
    void Update()
    {
        topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

        playerOffset.x = topRight.x - transform.position.x;
        playerOffset.y = topRight.y - transform.position.y;


    }
}
