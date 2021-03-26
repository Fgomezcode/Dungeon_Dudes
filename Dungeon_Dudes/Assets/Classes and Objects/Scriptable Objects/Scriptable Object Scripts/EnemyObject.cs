using UnityEngine;

[CreateAssetMenu(menuName = "Enemy", fileName = "Enemy_Obj")]

public class EnemyObject : ScriptableObject
{
    /*Enemy scriptable object, add stats as needed 
     * this is used to store data that other scripts
     * can access, do not modify this directly
     * changes persist
     */

    [Header("Enemy Stats")]
    public float maxHealth;
    //speed when aware of player
    public float chaseSpeed;
    //speed when not aware of player
    public float patrolSpeed;

    [Header("Damage Stats")]
    public float baseDamage;
    public float maxDamage;

    //shooting stats
    [Header("Shooting Stats")]
    public bool canShoot = false;
    [Range(0f, 10f)]
    public float lineOfSight;
    [Range(0f, 10f)]
    public float aggroLineOfSight;
    [Range(0f, 10f)]
    public GameObject projectile;
    public float shootingRange;
    public float projectileSpeed;
    public float projectileLife;
    public float fireRate;

    //sprite assets
    [Header("Character Sprites")]
    [SerializeField]
    public Sprite enemySprite;

    // sprite of enemy projectile
    [SerializeField]
    public Sprite enemyProjectileSprite;

    [Header("Loot Drops")]
    // loot pool 1D array that WILL hold item scriptable objects - guns, health, pwr up, money
    public int[] lootPool;

    [Header("Loot Type")]
    //bool values to open lootpools
    public bool isHealthDrop = false;
    public bool isManaDrop = false;
    public bool isKeyDrop = false;

    [Header("Spawn Enemy On Death")]
    public bool isSpawnMore = false;
 
}
