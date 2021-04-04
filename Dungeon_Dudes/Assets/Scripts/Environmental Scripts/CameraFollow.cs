using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /*This function makes the camera follow the main player,
     * it assigns the player tag id to playerToFollow on spawn.
     * FG 3/30
     */

    public GameObject playerToFollow;
    Transform target;
    public Vector3 offset;
    [Range(0.5f, 10f)]
    public float cameraSmoothing;

    private void Start()
    {
        findPlayer();
    }

    private void FixedUpdate()
    {
        if (playerToFollow = GameObject.FindGameObjectWithTag("Player"))
        {
            cameraControl();
        }
        if(gameObject.GetComponent<CameraFollow>().playerToFollow == null)
        {
            playerToFollow = GameObject.FindGameObjectWithTag("GameController");
        }
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
    }

    void findPlayer()
    {
        playerToFollow = GameObject.FindGameObjectWithTag("Player");
        target = playerToFollow.transform;
    }

    void cameraControl()
    {
        cameraDelay();
        playerToFollow = GameObject.FindGameObjectWithTag("Player");
        target = playerToFollow.transform;  
     
    }
}

