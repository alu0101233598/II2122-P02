using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherController : MonoBehaviour
{
    public float translationSpeed = 5f;
    
    private Rigidbody rb;
    private Renderer renderer;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        Vector3 mInput = new Vector3(Input.GetAxis("OtherHorizontal"), 0f, Input.GetAxis("OtherVertical"));
        rb.MovePosition(rb.position + (mInput * Time.deltaTime * translationSpeed));
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag != "Floor") {
            Debug.Log("Collisioned with " + other.gameObject.name);
            renderer.material.color = Color.HSVToRGB(Random.value, 0.5f, 0.9f);
        }
    }
}