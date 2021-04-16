using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int keyAmount;
    public int manaAmount;

    public Image key1;
    public Image key2;
    public Image key3;

    public Image mana1;
    public Image mana2;
    public Image mana3;

    

    private void Start()
    {
        displayKeys();
        displayMana();
    }

    public void displayKeys()
    {
        if(keyAmount == 0)
        {
            key1.GetComponent<HUDitem>().toggleImage();
            key2.GetComponent<HUDitem>().toggleImage();
            key3.GetComponent<HUDitem>().toggleImage();
        }
        if(keyAmount ==1 )
        {   
            key1.GetComponent<HUDitem>().toggleImage();
        }
        else if(keyAmount ==2)
        { 
            key2.GetComponent<HUDitem>().toggleImage();
        }
        else if(keyAmount ==3)
        {
            key3.GetComponent<HUDitem>().toggleImage();
        }
        else
        {
            return;
        }
    }

    public void displayMana()
    {
        if (manaAmount == 0)
        {
            mana1.GetComponent<HUDitem>().toggleImage();
            mana2.GetComponent<HUDitem>().toggleImage();
            mana3.GetComponent<HUDitem>().toggleImage();
        }
        if (manaAmount == 1)
        {
            mana1.GetComponent<HUDitem>().toggleImage();
        }
        else if (manaAmount == 2)
        {
            mana2.GetComponent<HUDitem>().toggleImage();
        }
        else if (manaAmount == 3)
        {
            mana3.GetComponent<HUDitem>().toggleImage();
        }
        else
        {
            return;
        }
    }
}
