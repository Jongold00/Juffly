using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastPointMouseFollow : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    public Vector3 dir;
    void Update()
    {
        
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = (playerTransform.position - worldPosition);
        dir.z = 0;
        dir.Normalize();
        transform.position = playerTransform.position - dir;
    }
}
