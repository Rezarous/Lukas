using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_Behaviour : MonoBehaviour
{


    public Game_Master manager;
    public int SunIndex; //first Sun = 0
    public Transform[] rotators;
    public int direction;

    Transform[] planets;
    int numberOfPlanets;


    void Start()
    {

        numberOfPlanets = rotators.Length;
        planets = new Transform[numberOfPlanets];

    }

    void Update()
    {


    }

    void OnMouseDown()
    {
        ClickBehvaiour();
    }


    void ClickBehvaiour()
    {
        if (Game_Master.allowToClick)
        {

            Game_Master.MoveIsHappening = true;
            manager.AssignPlants(SunIndex);
            UpdatePlanetsArray();
            for (int i = 0; i < numberOfPlanets; i++)
            {
                rotators[i].GetComponent<Movement_Behaviour>().MoveThisPlanet(planets[(i + 1) % numberOfPlanets].position);
            }

        }
    }


    void UpdatePlanetsArray()
    {

        for (int i = 0; i < rotators.Length; i++)
        {
            planets[i] = rotators[i].GetChild(0);
        }

    }

}



//if(Input.touchCount > 0){
//    Touch touch = Input.GetTouch(0);
//    Vector2 vTouchPos = touch.position;

//    // The ray to the touched object in the world
//    Ray ray = Camera.main.ScreenPointToRay(vTouchPos);

//    // Your raycast handling
//    RaycastHit vHit;
//    if (Physics.Raycast(ray.origin, ray.direction, out vHit))
//    {
//        if (vHit.transform.tag == "Sun")
//        {
//            ClickBehvaiour();
//        }
//    }
//}

