using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField] private Transform objectToMove;
    [SerializeField] private bool rotateObject;

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }


    private void MoveObject()
    {
        // Rotate the object
        if (rotateObject)
        {
            objectToMove.rotation = Quaternion.Euler(0, 0, Time.time * 100);
        }
        else
        {
            // Move the object to the new position
            objectToMove.position += Vector3.right;
        }
    }
}
