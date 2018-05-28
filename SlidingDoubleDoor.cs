using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoubleDoor : MonoBehaviour {

    public float slideAmount;
    public float slideSpeed;
    public bool TriggerEntered;

    public GameObject LeftDoor;
    public GameObject RightDoor;

    float rdx;
    float ldx;

    // Use this for initialization
    void Start () {
        rdx = RightDoor.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (TriggerEntered)
        {

        }
	}

    void OnTriggerEnter()
    {
        RightDoor.transform.Translate(new Vector3(slideAmount , 0, 0));
        LeftDoor.transform.Translate(new Vector3(-slideAmount , 0, 0));
    }
}
