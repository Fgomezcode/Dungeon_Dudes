using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSortingLayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer sprite = collision.GetComponent<SpriteRenderer>();

        sprite.sortingOrder = -1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SpriteRenderer sprite = collision.GetComponent<SpriteRenderer>();

        sprite.sortingOrder = 1;
    }
}
