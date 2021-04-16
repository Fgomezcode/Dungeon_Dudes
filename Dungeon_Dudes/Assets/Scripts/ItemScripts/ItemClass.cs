using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClass : MonoBehaviour
{
    public ItemObject itemClass;
    public PlayParticle itemParticle;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = itemClass.itemSprite;
        itemParticle = GetComponentInChildren<PlayParticle>();
    }


    //setup collisions;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        CharacterClass player = collision.collider.GetComponent<CharacterClass>();
        if(itemClass.isHeal && player)
        {
            player.gameObject.GetComponent<PlayerHealth>().healPlayer(itemClass.healAmount);
            Debug.LogError("PLAYER HEALED");
            hideItem();
            
        }

        if (itemClass.isKey && player)
        {
            GameManager hud = FindObjectOfType<GameManager>();
            if(hud.keyAmount< player.character.keys)
            {
                hud.keyAmount++;
                hud.displayKeys();
                hideItem();
            }      
            hideItem();
            Debug.LogError("PLAYER GOT KEY");     
        }

        if (itemClass.isMana && player)
        {
            GameManager hud = FindObjectOfType<GameManager>();

            if(hud.manaAmount < player.character.mana)
            {
                hud.manaAmount++;
                hud.displayMana();
                hideItem();
            }
           
            hideItem();
            Debug.LogError("PLAYER GOT MANA");

        }
    }


    public void hideItem()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 1f);
    }


}
