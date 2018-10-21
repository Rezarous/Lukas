using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[ExecuteInEditMode]
public class Camera_Controller : MonoBehaviour {

    public float horizontalResolution = 1920;

    public Vector3[] levelPositions;
    public Vector3[] levelRotations;
    public Vector3[] levelScales;

    public int level = 1;
    //int lastLevel = 1;

    public bool startMoving = false;

    void OnGUI()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        Camera.main.orthographicSize = horizontalResolution / currentAspect / 200;
    }

    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space)){
        //    if (level == 1){
        //        level = 2;
        //    }else if (level == 2){
        //        level = 1;
        //    }
        //    MoveCamera();
        //}
        //// Just for Editor
        //if(lastLevel != level){
        //    MoveCamera();
        //    lastLevel = level;
        //}

        if(startMoving){
            MoveCamera();
        }

    }


    void MoveCamera(){
        transform.position = Vector3.Lerp(transform.position, levelPositions[level - 1], 5 * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(levelRotations[level - 1]), 5 * Time.deltaTime);
        //transform.position = levelPositions[level - 1];
        //transform.rotation = Quaternion.Euler(levelRotations[level - 1]);

    }


}

