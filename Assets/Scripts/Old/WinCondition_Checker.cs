using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition_Checker : MonoBehaviour {

    public GameObject[] planets;
    public GameObject[] rings;

    int numberofPlaents;

	// Use this for initialization
	void Start () {

        numberofPlaents = Behaviour_Manager.numberOfPlanets;
        planets = new GameObject[numberofPlaents];
        rings = new GameObject[numberofPlaents];
    }
	
	// Update is called once per frame
	void Update () {

        //if(rings[0].transform.position == planets[0].transform.position){
        //    print("yes");
        //}

	}
}
