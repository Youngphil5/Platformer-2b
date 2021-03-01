using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
   public Transform tragetPos;
   public Vector3 offset;
   [Range (1,10)]
   public float smoothFactor;
   

   private void FixedUpdate()
   {
      Follow();
   }

   void Follow()
   {
      Vector3 targetPos = tragetPos.position + offset;
      Vector3 smoothTransion = Vector3.Lerp(transform.position, targetPos, smoothFactor * Time.deltaTime);
      //Smoothly moves the camera to were the target postion for a sec or 2 then the code bellow takes over
      
      transform.position = smoothTransion;
      

   }
}
