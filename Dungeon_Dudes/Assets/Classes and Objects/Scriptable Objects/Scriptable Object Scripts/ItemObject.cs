using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "Item_Obj")]
public class ItemObject : ScriptableObject
{
    [Header("Item Type")]
    public bool isHeal;
    public bool isMana;
    public bool isKey;
    public bool isTreasure;
   
   
    public float healAmount;
    public int treasureAmount;

    public Sprite itemSprite;

    public ParticleSystem itemParticles;

    
}
