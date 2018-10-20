using UnityEngine;
using System.Collections;

public class Behaviour_Manager: MonoBehaviour
{
    public static int numberOfPlanets;
    public GameObject[] cubes;

    // the game field stores where our cubes are
    private int[] gameField;

    // Use this for initialization
    void Start()
    {
        // set cubes to the correct position
        //cubes[0].transform.position = new Vector3(0, 0, 0);
        //cubes[1].transform.position = new Vector3(-2, 0, 0);
        //cubes[2].transform.position = new Vector3(-1, 2, 0);
        //cubes[3].transform.position = new Vector3(2, 0, 0);
        //cubes[4].transform.position = new Vector3(1, -2, 0);

        // initialize game field
        gameField = new int[cubes.Length];
        for (int i = 0; i < cubes.Length; ++i)
        {
            gameField[i] = i;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            MoveTriple(0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveTriple(3);
        }
        //if (GameObject.Find("Orange").transform.position == new Vector3(0, 0, 0))
        //{
        //    Debug.Log("You Won!");
        //}
    }

    //public void MoveTwo(int startIndex)
    //{
    //    int index0 = (startIndex + 0) % gameField.Length;
    //    int index1 = (startIndex + 1) % gameField.Length;
    //    Movement mov0 = cubes[gameField[index0]].GetComponent<Movement>();
    //    Movement mov1 = cubes[gameField[index1]].GetComponent<Movement>();
    //    if (!mov0.HasToMove() && !mov1.HasToMove())
    //    {
    //        // get current positions of cubes
    //        Vector3 pos0 = cubes[gameField[index0]].transform.position;
    //        Vector3 pos1 = cubes[gameField[index1]].transform.position;

    //        // move them!
    //        mov0.MoveToDestination(pos1);
    //        mov1.MoveToDestination(pos0);

    //        // update game field with new ids
    //        int id0 = gameField[index0];
    //        int id1 = gameField[index1];
    //        gameField[index0] = gameField[index1];
    //        gameField[index1] = id0;
    //    }
    //}

    // moves 3 cubes which are selected by a starting index from the game field
    public void MoveTriple(int startIndex)
    {
        // calculate needed indices to find correct cubes
        int index0 = (startIndex + 0) % gameField.Length;
        int index1 = (startIndex + 1) % gameField.Length;
        int index2 = (startIndex + 2) % gameField.Length;

        // get cube scripts to work with them
        Movement mov0 = cubes[gameField[index0]].GetComponent<Movement>();
        Movement mov1 = cubes[gameField[index1]].GetComponent<Movement>();
        Movement mov2 = cubes[gameField[index2]].GetComponent<Movement>();

        // only move them if they are not still moving
        if (!mov0.HasToMove() && !mov1.HasToMove() && !mov2.HasToMove())
        {
            // get current positions of cubes
            Vector3 pos0 = cubes[gameField[index0]].transform.position;
            Vector3 pos1 = cubes[gameField[index1]].transform.position;
            Vector3 pos2 = cubes[gameField[index2]].transform.position;

            // move them!
            mov0.MoveToDestination(pos2);
            mov1.MoveToDestination(pos0);
            mov2.MoveToDestination(pos1);

            // update game field with new ids
            int id0 = gameField[index0];
            int id2 = gameField[index2];
            gameField[index0] = gameField[index1];
            gameField[index1] = id2;
            gameField[index2] = id0;
        }
    }


}
