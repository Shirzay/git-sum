using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitchCursorMove : MonoBehaviour {

    public float radius = 0.450f;
    public float speed = 20;
    public string weaponString;

    public float maxDist;
    private Vector2 primaryAxis;
    private Vector3 velocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        // print(primaryAxis);
        //transform.localPosition = new Vector3(primaryAxis.x * 15 * (Time.deltaTime * speed), primaryAxis.y* 15 * (Time.deltaTime * speed), 0);

        // transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(primaryAxis.x * maxDist * (Time.deltaTime * speed), primaryAxis.y * maxDist * (Time.deltaTime * speed), 0), 1.0f);
        Vector3 targetPosition = new Vector3(primaryAxis.x * maxDist * (Time.deltaTime * speed), primaryAxis.y * maxDist * (Time.deltaTime * speed), 0);
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, targetPosition, ref velocity, 0.02f);


    }

    private void LateUpdate()
    {
        //float xAxis = Mathf.Clamp(primaryAxis.x, -maxDist * primaryAxis.x, maxDist * primaryAxis.x);
        //float yAxis = Mathf.Clamp(primaryAxis.y, -maxDist * primaryAxis.y, maxDist * primaryAxis.y);
       // Vector3 targetPosition = new Vector3(primaryAxis.x * maxDist * (Time.deltaTime * speed), primaryAxis.y * maxDist * (Time.deltaTime * speed), 0);
       // transform.localPosition = Vector3.SmoothDamp(transform.localPosition, targetPosition, ref velocity, 0.02f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // print(other.name);
        weaponString = other.name;
    }
}
