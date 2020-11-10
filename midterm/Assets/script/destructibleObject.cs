using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructibleObject : MonoBehaviour, IDamageable
{

    public float MaxHealth = 100.0f;
    private float currentHealth;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided with: "+collision.gameObject.name);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
