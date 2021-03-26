using UnityEngine;

[CreateAssetMenu(menuName = "Enemy", fileName = "Enemy_Obj")]

public class EnemyObject : ScriptableObject
{
    [Header("Enemy Stats")]
    public float maxHealth;
   
    //speed when aware of player
    public float chaseSpeed;

    //speed when not aware of player
    public float patrolSpeed;

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
