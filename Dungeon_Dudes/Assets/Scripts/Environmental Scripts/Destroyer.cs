using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
  
    public void kill()
    {
        Destroy(gameObject, 1f);

    }
 
}
