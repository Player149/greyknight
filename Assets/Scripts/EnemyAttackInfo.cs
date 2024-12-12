using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackInfo : MonoBehaviour
{
    public float Damage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LivingCreature lc = collision.gameObject.GetComponent<LivingCreature>();
            if(lc == null)
            {
                lc = collision.gameObject.GetComponentInParent<LivingCreature>();
            }
            lc.Damaged(Damage);
        }
    }
}
