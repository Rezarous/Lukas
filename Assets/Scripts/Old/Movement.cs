using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed = 5f;

    private bool hasToMove;
    private Vector3 destination;
    private Vector3 centerPoint;

    // Use this for initialization
    void Start()
    {
        hasToMove = false;
        destination = Vector3.zero; // this is not really required
    }

    // Update is called once per frame
    void Update()
    {
        // only do something if you have to
        if (hasToMove)
        {
            // get remaining distance
            float distance = Vector3.Distance(transform.position, destination);

            // smoothly move closer to destination with respect to speed
            //transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * (speed / distance));
            transform.RotateAround(centerPoint, Vector3.forward, Time.deltaTime * (speed / distance));

            // if this is smaller than some epsilon, stop it
            hasToMove = distance > 1e-3;
        }
    }

    public bool HasToMove()
    {
        return hasToMove;
    }

    public void MoveToDestination(Vector3 dest, Vector3 center)
    {
        // start moving 
        hasToMove = true;

        // to this destination
        destination = dest;

        centerPoint = center;
    }
}
