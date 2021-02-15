﻿using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 6f;            // kecepatan player


        Vector3 movement;                   // vektor dari arah player
        Animator anim;                      // komponen animator
        Rigidbody playerRigidbody;          // player rigidbody

        int floorMask;                      
        float camRayLength = 100f;          

        void Awake ()
        {

            // layer mask buat floor
            floorMask = LayerMask.GetMask ("Floor");

            // reference
            anim = GetComponent <Animator> ();
            playerRigidbody = GetComponent <Rigidbody> ();
        }


        void FixedUpdate ()
        {
            // Store the input axes.
            //float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            //float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            // gerakin pemain
            Move (h, v);

            // membuat player turn ke cursor
            Turning ();

            // Animasi player
            Animating (h, v);
        }


        public void Move (float h, float v)
        {
            // Pergerakan pemain berdasarkan axis
            movement.Set (h, 0f, v);
            
            // Normalisasi gerakan dan memproporsionalkan kecepatan
            movement = movement.normalized * speed * Time.deltaTime;

            // Gerakin pemain ke posisi yg seharusnya
            playerRigidbody.MovePosition (transform.position + movement);
        }


        void Turning ()
        {

            Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

            // Raycast hit
            RaycastHit floorHit;

            
            if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
            {
                
                Vector3 playerToMouse = floorHit.point - transform.position;

                playerToMouse.y = 0f;

                Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);

                playerRigidbody.MoveRotation (newRotatation);
            }
//#else

//            Vector3 turnDir = new Vector3(CrossPlatformInputManager.GetAxisRaw("Mouse X") , 0f , CrossPlatformInputManager.GetAxisRaw("Mouse Y"));
//
  //          if (turnDir != Vector3.zero)
    //        {
      //          // Create a vector from the player to the point on the floor the raycast from the mouse hit.
        //        Vector3 playerToMouse = (transform.position + turnDir) - transform.position;
        //
          //      // Ensure the vector is entirely along the floor plane.
            //    playerToMouse.y = 0f;
            //
              //  // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
                //Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

                // Set the player's rotation to this new rotation.
              //  playerRigidbody.MoveRotation(newRotatation);
            //}
//#endif
        }


        public void Animating (float h, float v)
        {
           
            bool walking = h != 0f || v != 0f;

            // Walking or not
            anim.SetBool ("IsWalking", walking);
        }
    }
}