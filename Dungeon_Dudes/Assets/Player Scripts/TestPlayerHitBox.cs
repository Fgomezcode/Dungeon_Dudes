using UnityEngine;

// refactor this into a new script
// called PlayerEnvironmentalCollision
// it will only be used when colliding with
// the world, not NPC/Players
//FG - 3/25 @2am

public class TestPlayerHitBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //assign the item you are colliding with to a var
        Damageable destructableItem = collision.GetComponent<Damageable>();
        float dmg = collision.GetComponent<DestructableObject>().basicDamage;
        //make sure item has damageable class before calling func
        if(destructableItem != null)
        {
            //need to make player stats so it is not hard coded
            //and can be modified later

            destructableItem.applyDamage(dmg);
            Debug.Log(destructableItem.health);
        }
    }
}
