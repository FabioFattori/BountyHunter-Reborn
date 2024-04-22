using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Zombie : Enemy
{


    void OnCollisionEnter2D(Collision2D collision)
    {
        //check that the collision is with the player NOT the attack area

        if (collision.gameObject.CompareTag("Player"))
        {
            //get the player health script
            EntityHealtBar playerHealth = collision.gameObject.GetComponent<EntityHealtBar>();

            //get the player position
            Vector2 playerPosition = collision.gameObject.transform.position;

            //get the zombie position
            Vector2 zombiePosition = this.transform.position;

            //get the direction from the zombie to the player
            Vector2 direction = playerPosition - zombiePosition;
            direction = new Vector2(Mathf.Floor(Math.Abs(direction.x)), Mathf.Floor(Math.Abs(direction.y)));
            Debug.Log(direction);
            Debug.Log("X: " + direction.x + " Y: " + direction.y);
            if((direction.x == 0 && direction.y <= 1) || (direction.y == 0 && direction.x <= 1) || (direction.x == 1 && direction.y == 1)){
                playerHealth.TakeDamage(this.getDamage());
            }

        }
    }
}