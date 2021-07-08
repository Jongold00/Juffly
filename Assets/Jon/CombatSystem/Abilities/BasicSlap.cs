using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicSlap : AAbility
{
   
    public override void Cast(Transform playerTransform)
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, playerTransform.position.z));
        Vector3 castDir = worldMousePosition - playerTransform.position;
        castDir.Normalize();
        // print("cast direction: " + castDir);
        if (Physics2D.Raycast(playerTransform.position, castDir, 2))
        {
            print("hit");
        }
    }
    
}
