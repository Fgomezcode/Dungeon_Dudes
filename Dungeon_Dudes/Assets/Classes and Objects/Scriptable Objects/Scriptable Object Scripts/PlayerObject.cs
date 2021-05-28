using UnityEngine;

[CreateAssetMenu(menuName = "Player", fileName ="Pl_Class")]
public class PlayerObject : ScriptableObject
{
    /*This scriptable object is used to create
     * classes for the player, it delares all
     * of the class attributes, and allow you 
     * to edit them in the Editor to avoid hardcoding 
     * and make tweaking easier
     * FG 3/25
     */
    
    [Header("Character Stats")]
    public float maxHealth;
    public float maxStamina;
    public float staminaRegenRate;
    public float staminaBurnRate;
    public float staminaDodgeCost;
    public float dodgeDistance;
    public float MoveSpeed;
    public float minMoveSpeed;

    [Header("Damage Done to Enemy on Collision")]
    public float collisionDamage;

    [Header("Melee Attack Damage")]
    public float meleeDamage;
    public float meleeDelay;
    public float meleeStaminaCost;
    public float meleeWallBreakCost;

    [Header("Projectile Damage")]
    public float projectileDamage;
    //these values set inventory limits
    [Header("Inventory Space")]
    [Tooltip("Set Max value: ")]
    public int keys;
    public int mana;

    //sprite assets
    [Header("Character Sprites")]

    [SerializeField]
    public Sprite playerSprite;
    
    [SerializeField]
    [Header("Shooting Stats")]
   // public Sprite playerProjectileSprite;
    public GameObject playerProjectile;

    //public string classTag;
    //public Animator animator;
   
}
