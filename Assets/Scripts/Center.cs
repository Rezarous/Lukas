using UnityEngine;
using System.Collections;

public class Center : MonoBehaviour
{

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public int numberOfIndex;
    Behaviour_Manager manager;

    // Use this for initialization
    void Start()
    {
        //transform.position = (one.transform.position + two.transform.position + three.transform.position) / 3;
        manager = GameObject.FindObjectOfType(typeof(Behaviour_Manager)) as Behaviour_Manager;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        manager.MoveTriple(numberOfIndex);
    }



}
