using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealtBar : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public bool canRegen = false;

    private int oldFrameHealth;

    private int regenRate; //health per second 1/16 of the max health

    private float timer = 0; 

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
        
        if(this.CompareTag("Player"))
        {
            GameObject.Find("ChangeScene").GetComponent<SceneChanger>().ChangeScene(SceneChanger.Scene.GameOver);
        }
        else if(this.CompareTag("Enemy"))
        {
            GameObject.Find("EnemyManager").GetComponent<EnemySpawner>().removeEnemy(GetComponent<Enemy>().getID());
        }
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
            timer = 0;

        }

        if(canRegen)
        {
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                currentHealth += maxHealth / 16;
                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }
                graphicHealtBar.value = currentHealth;
            }
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
        //get the slider component which is in a canvas object
        GetComponentInChildren<Canvas>().GetComponentInChildren<Slider>().maxValue = maxHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    
}
