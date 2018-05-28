using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Avatar;
using Oculus.Platform;

public class Jetpack : MonoBehaviour {

    private CharacterController cc;
    private Vector3 moveDirection = Vector3.zero;
    private float jumpSpeed = 300f;

    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

       if( OVRInput.Get(OVRInput.Button.One )){
            moveDirection.y = jumpSpeed;
        }

       cc.Move(moveDirection * Time.deltaTime);

    }
}
