using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    //Tells the level walker to delete a poorly placed room.
    //FG 4/11
    public int type;

    public void roomDestruction()
    {
        Destroy(gameObject);
    }
}
