using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealtBar : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private int oldFrameHealth;

    public Slider graphicHealtBar;


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        oldFrameHealth = currentHealth;
        graphicHealtBar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (oldFrameHealth != currentHealth)
        {
            graphicHealtBar.value = currentHealth;
            oldFrameHealth = currentHealth;

        }
    }

    public void setHealth(int health)
    {
        currentHealth = health;
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void setMaxHealth(int health)
    {
        maxHealth = health;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    
}
