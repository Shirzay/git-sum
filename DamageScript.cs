using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

    public float hp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
		
	}

    public void AddDamage(float f)
    {
        hp -= f;
    }


    
}
