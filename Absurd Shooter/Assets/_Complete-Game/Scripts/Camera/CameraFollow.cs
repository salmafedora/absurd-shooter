using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;            // kamera bakal ngikutin
        public float smoothing = 5f;        // ngatur kecepatan kamera

        Vector3 offset;                     // initial offset dari target


        void Start ()
        {
            // Menghitung initial offset.
            offset = transform.position - target.position;
        }


        void FixedUpdate ()
        {
            // Posisi kamera berdasarkan offset
            Vector3 targetCamPos = target.position + offset;

            // Supaya kamera smooth
            transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}