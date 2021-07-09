using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicSlap : AbilityFactory
{
   
    public override void Cast(GameObject playerTransform)
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, playerTransform.transform.position.z));
        Vector3 castDir = worldMousePosition - playerTransform.transform.position;
        castDir.Normalize();
        // print("cast direction: " + castDir);
        if (Physics2D.Raycast(playerTransform.transform.position, castDir, 2))
        {
            print("hit");
        }
    }
    
}
