﻿using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;





    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy  (this.gameObject );

            // Get a reference to the Applepicker components of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>() ;
            //Call the public AppleDestroyed() method of apScript
            apScript.AppleDestroyed();

        }

    }
}