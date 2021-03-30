using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /*This function makes the camera follow the main player,
     * it assigns the player tag id to playerToFollow on spawn.
     */
    public GameObject playerToFollow;

    Transform target;

    public Vector3 offset;

    [Range(0.5f, 10f)]
    public float cameraSmoothing;

    private void Start()
    {
        playerToFollow = GameObject.FindGameObjectWithTag("Player");
        target = playerToFollow.transform;
    }

    private void FixedUpdate()
    {
        cameraDelay();
    }

    void cameraDelay()
    {
        if(target)
        { 
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, cameraSmoothing * Time.fixedDeltaTime);
            transform.position = smoothPosition;
        }
        else
        {
            Vector3 targetPosition = gameObject.transform.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, cameraSmoothing * Time.fixedDeltaTime);
            transform.position = smoothPosition;

        }
        //Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, cameraSmoothing * Time.fixedDeltaTime);
        //transform.position = smoothPosition;
    }
}

