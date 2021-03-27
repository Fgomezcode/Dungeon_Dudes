using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //not finished or attached to camera.
    //FG 3/27


    public Camera mainCamera;
    public Transform playerToFollow;


    void Start()
    {
        mainCamera.transform.position = playerToFollow.transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        mainCamera.transform.position = playerToFollow.transform.position;
    }
}
