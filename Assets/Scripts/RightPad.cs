using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPad : MonoBehaviour {

    float speed = 12.0f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up") && transform.position.y < 5.752)
        {   
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey("down") && transform.position.y > -3.549)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
