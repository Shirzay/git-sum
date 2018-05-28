using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupSpin : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));

        transform.Translate(new Vector3(0, Mathf.Sin(Time.time) * Time.deltaTime / 6, 0));

	}
}
