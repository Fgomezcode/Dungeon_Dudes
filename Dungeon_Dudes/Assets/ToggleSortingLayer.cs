using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSortingLayer : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer sprite = collision.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Walls";
        sprite.sortingOrder = -1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SpriteRenderer sprite = collision.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Player";
        sprite.sortingOrder = 1;
    }
}
