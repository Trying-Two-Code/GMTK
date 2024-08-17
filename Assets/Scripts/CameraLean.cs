using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLean : MonoBehaviour
{
    float xRot;
    float zRot;
    float hoz;
    float vrt;
    [SerializeField] private bool x, z;
    [SerializeField] private float tiltSpeed;
    [SerializeField] private float tiltStrength;
    [SerializeField] private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Z axis for hoz

        // Get keyboard input
        hoz = Input.GetAxisRaw("Horizontal");
        vrt = Input.GetAxisRaw("Vertical");

        // Lerp smoothly based on tiltSpeed
        zRot = Mathf.Lerp(zRot, hoz * tiltStrength, tiltSpeed * Time.deltaTime);
        xRot = Mathf.Lerp(xRot, vrt * tiltStrength, tiltSpeed * Time.deltaTime);

        // Rotate Camera
        transform.localRotation = Quaternion.Euler(x ? xRot:transform.localRotation.x, transform.localRotation.y, z ? -zRot: transform.localRotation.z);
    }
}
