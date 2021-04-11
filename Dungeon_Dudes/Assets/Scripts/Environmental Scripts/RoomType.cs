using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    public int type;

    private void Start()
    {
        Invoke("turnOffCollider",4);
    }
    void turnOffCollider()
    {
        BoxCollider2D roomCollider = GetComponent<BoxCollider2D>();

        Destroy(roomCollider);
    }
    public void roomDestruction()
    {
        Destroy(gameObject);
    }
}
