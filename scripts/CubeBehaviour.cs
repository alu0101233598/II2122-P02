using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    public float scaleSpeed = 1.5f;

    private SphereCollider collider;
    private float radius;
    private Vector3 originalSize;

    void Awake()
    {
        collider = GetComponent<SphereCollider>();
        originalSize = transform.localScale;
        radius = collider.radius * originalSize.x;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Sphere" || other.gameObject.tag == "Player") {
            float distance = Vector3.Distance(other.gameObject.transform.position, transform.position);
            if (distance < radius)
            {
                float scaleAmount = (other.gameObject.tag == "Player" ? -1 : 1) * (1 - distance / radius) * scaleSpeed;
                transform.localScale = new Vector3(originalSize.x + scaleAmount, originalSize.y + scaleAmount, originalSize.z + scaleAmount);
            }
        }
    }
}