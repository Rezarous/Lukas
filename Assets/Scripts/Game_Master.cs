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


    void Start () {

        numberOfPlanets = gameField.Length;
        numberOfSuns = suns.Length;

        UpdateIndexOfPlanets();

    }
	

	void Update () {
		
	}

    ///////WRONG
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
            Camera.main.GetComponent<Camera_Controller>().startMoving = true;
        }
    }

}
