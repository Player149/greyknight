using UnityEngine;

public class LivingCreature : MonoBehaviour
{
    public float MaxHealth;
    public float currentHealth;
    public int id;

    public bool Dead;

    public virtual void Start()
    {
        IdManager.instance.idMaking(this);
    }
    private void OnEnable()
    {
        currentHealth = MaxHealth;
        Dead = false;
    }
    public virtual void Damaged(float damage)
    {
        HealthPM(damage);
    }
    public virtual void HealthPM(float damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Dead = true;
        gameObject.SetActive(false);
    }
}
