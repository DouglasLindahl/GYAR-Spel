using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float lifetime;
    public int speed = 50;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
        Destroy(gameObject, lifetime);
    }
}
