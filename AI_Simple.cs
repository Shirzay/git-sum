using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Simple : MonoBehaviour {

    private NavMeshAgent nma;

    public GameObject player;

	// Use this for initialization
	void Start () {
        nma = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

        if(player == null)
        {
            player = GameObject.Find("Player");
        }

        nma.destination = player.transform.position;

	}
}
