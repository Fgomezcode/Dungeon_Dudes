using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDitem : MonoBehaviour
{
    Image uiImage;

     void Start()
    {
        uiImage = GetComponent<Image>();
    }
    public void toggleImage()
    {
        
        uiImage.enabled = !uiImage.enabled;
     }
}
