using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newBall2 : MonoBehaviour {

    Rigidbody rb;
    Vector3 oldVel;
    public float force = 1000f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * force);
    }

    void FixedUpdate()
    {
        oldVel = rb.velocity;
    }

    void OnCollisionEnter(Collision c)
    {
        ContactPoint cp = c.contacts[0];
        // calculate with addition of normal vector
        // myRigidbody.velocity = oldVel + cp.normal*2.0f*oldVel.magnitude;

        // calculate with Vector3.Reflect
        rb.velocity = Vector3.Reflect(oldVel, cp.normal);

      
    }
}
