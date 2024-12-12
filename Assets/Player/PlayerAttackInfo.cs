using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInfo : MonoBehaviour
{
    public float Damage;
    List<int> Ids = new List<int>();
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            LivingCreature lc = collision.gameObject.GetComponent<LivingCreature>();
            if (!Ids.Contains(lc.id))
            {
                lc.Damaged(Damage);
                Ids.Add(lc.id);
            }
        }
    }
    private void OnDisable()
    {
        Ids.Clear();
    }
}
