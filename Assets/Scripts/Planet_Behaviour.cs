using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Behaviour : MonoBehaviour {

    public int indexInField;
    public enum ColorCode { Red, Blue, Yellow, Purple};
    public ColorCode planetColor;
    private Quaternion initialRotation;

    // Use this for initialization
    void Start () {
        initialRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if(Game_Master.MoveIsHappening){

            transform.rotation = initialRotation;

        }
	}
}
