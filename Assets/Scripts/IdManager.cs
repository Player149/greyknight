using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class IdManager : MonoBehaviour
{
    public static IdManager instance;
    public List<int> Ids = new List<int>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void idMaking(LivingCreature livingCreture)
    {
        int newId = Random.Range(0, sizeof(int));
        while (Ids.Contains(newId))
        {
            newId = Random.Range(0, sizeof(int));
        }
        livingCreture.id = newId;
    }
}
