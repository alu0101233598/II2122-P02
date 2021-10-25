using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerRB : MonoBehaviour
{
    public float translationSpeed = 5f;
    public float rotationSpeed = 100f;
    
    private Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 mInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 rInput = new Vector3(0f, Input.GetAxis("Up"), 0f);
        Vector3 deltaPosition = transform.TransformDirection(mInput * Time.deltaTime * translationSpeed);
        Quaternion deltaRotation = Quaternion.Euler(rInput * Time.deltaTime * rotationSpeed);
        rb.MovePosition(rb.position + deltaPosition);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}