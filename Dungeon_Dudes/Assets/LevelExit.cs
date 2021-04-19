using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement playerMovement = collision.GetComponent<Movement>();
        SpriteRenderer playerSprite = collision.GetComponent<SpriteRenderer>();
        
        if(playerMovement && playerSprite)
        {

            collision.transform.position = Vector2.MoveTowards(collision.transform.position, transform.position, 0.5f*Time.deltaTime);
            //playerMovement.enabled = false;
            //playerSprite.enabled = false;
            gameManager.currentLevel++;
            gameManager.updateLevel();
        }
    }

}
