using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    public float health = 50.0f;
    public float point = 0;
    
  
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0.0f)
        {
            point += 10;
            Destroy(this.gameObject);
        }
       
    }

    public void OnDestroy()
    {
        print("Ai was destroyed");
        enemyspawn.Instance.mcount++;
        
    }
}
