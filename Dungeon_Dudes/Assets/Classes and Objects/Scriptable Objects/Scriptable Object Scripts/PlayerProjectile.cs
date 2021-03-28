using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerProjectile", fileName = "PlayerProjectile")]
public class PlayerProjectile : ScriptableObject
{
    //This is a scriptable object that controls the properties of player projectiles
    // think of this as different weapons.

    public Sprite playerProjectileSprite;
    public float playerProjectileSpeed;
    public float playerProjectileReload;
    public float playerProjectileTimer;
    [Header("Time Before Destroy")]
    public float playerProjectileLife;

}
