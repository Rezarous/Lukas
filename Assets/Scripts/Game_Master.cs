using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Game_Master : MonoBehaviour {


    public GameObject[] gameField;
    public GameObject[] suns;
    public GameObject[] rings;
    int numberOfPlanets;
    int numberOfSuns;

    public bool levelWon = false;
    public static bool allowToClick = true;
    public static bool MoveIsHappening = false;

    //Level and camera stuff
    public Vector3[] levelPositions;
    public Vector3[] levelRotations;
    public Vector3[] levelScales;
    public int level = 1;
    public bool goToNextLevel = false;
    private bool startMovingCamera = false;
    private Camera camera;
    private float cameraSpeed = 2.5f;


    void Start () {

        numberOfPlanets = gameField.Length;
        numberOfSuns = suns.Length;


        // Update Index Of Planets
        for (int i = 0; i < gameField.Length; i++)
        {
            gameField[i].GetComponent<Planet_Behaviour>().indexInField = i;
        }

        // Set the camera in the right palce
        camera = Camera.main;
        SetCamera();
    }
	

	void Update () {

        allowToClick = !MoveIsHappening;


        // Next Level and Camera Movement Behaviour
        if (goToNextLevel)
        {
            level++;
            startMovingCamera = true;
            goToNextLevel = false;
        }

        if (startMovingCamera)
        {
            if(!MoveIsHappening){
                float distance = Vector3.Distance(camera.transform.position, levelPositions[level - 1]);
                if (distance > 0.1f)
                {
                    allowToClick = false;
                    distance = Vector3.Distance(camera.transform.position, levelPositions[level - 1]);
                    MoveCamera();
                }
                else
                {
                    allowToClick = true;
                    startMovingCamera = false;
                }
            }
        }

    }


    void MoveCamera()
    {
        camera.transform.position = Vector3.Lerp(camera.transform.position, levelPositions[level - 1], cameraSpeed * Time.deltaTime);
        camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, Quaternion.Euler(levelRotations[level - 1]), cameraSpeed * Time.deltaTime);
    }


    void SetCamera(){
        camera.transform.position = levelPositions[level - 1];
        camera.transform.rotation = Quaternion.Euler(levelRotations[level - 1]);
    }


    public void UpdateGameField(int sunIndex){ 

        int firstIndex = 2 * sunIndex;
        GameObject temp = gameField[firstIndex + 2];
        gameField[firstIndex + 2] = gameField[firstIndex + 1];
        gameField[firstIndex + 1] = gameField[firstIndex];
        gameField[firstIndex] = temp;
        UpdateIndexOfPlanets();
    }

    public void AssignPlants(int sunIndex){

        allowToClick = false;

        int firstIndex = 2 * sunIndex;
        gameField[firstIndex].transform.parent = suns[sunIndex].transform.GetChild(0).GetChild(0);
        gameField[firstIndex+1].transform.parent = suns[sunIndex].transform.GetChild(0).GetChild(1);
        gameField[firstIndex+2].transform.parent = suns[sunIndex].transform.GetChild(0).GetChild(2);
        UpdateGameField(sunIndex);
    }

    void UpdateIndexOfPlanets(){
        for (int i = 0; i < gameField.Length; i++){
            gameField[i].GetComponent<Planet_Behaviour>().indexInField = i;
        }
        CheckWinningCondition();
    }

    //void CheckWinningCondition(){
    //    for (int i = 0; i < gameField.Length; i++){
    //        //print(gameField[i].GetComponent<Planet_Behaviour>().planetColor.ToString());
    //        if (gameField[i].GetComponent<Planet_Behaviour>().planetColor.ToString().Equals(rings[i].GetComponent<Ring_Bahaviour>().ringColor.ToString())){
    //            //print(gameField[i].GetComponent<Planet_Behaviour>().planetColor.ToString() + "===" + rings[i].GetComponent<Ring_Bahaviour>().ringColor.ToString());
    //            //print("VICTORY!");
    //        }
    //    }
    //}

    void CheckWinningCondition()
    {
        int numberOfCorrectPlanets = 0;
        for (int i = 0; i < gameField.Length; i++)
        {
            if (gameField[i].GetComponent<Planet_Behaviour>().planetColor.ToString().Equals(rings[i].GetComponent<Ring_Bahaviour>().ringColor.ToString()))
            {
                print("here");
                numberOfCorrectPlanets++;
            }
        }
        if (numberOfCorrectPlanets == gameField.Length)
        {
            print("Victory");
            goToNextLevel = true;
        }
    }

}
