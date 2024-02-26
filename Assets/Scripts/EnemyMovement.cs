using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movSpeed = 3f;
    Vector2 movement;
    public Rigidbody2D rb;

    public Rigidbody2D player;


    // Update is called once per frame
    void Update()
    {
        int perc = Random.Range(0, 10);

        if (perc < 5)
        {
            movement.x = player.position.x - rb.position.x;
            movement.y = player.position.y - rb.position.y;
        }
        else
        {
            movement.y = randomDirectionY();
            movement.x = randomDirectionX();
        }
    }

    private float randomDirectionX()
    {
        return Random.Range(rb.position.x - movSpeed, rb.position.x + movSpeed);
    }

    private float randomDirectionY()
    {
        return Random.Range(rb.position.y - movSpeed, rb.position.y + movSpeed);
    }

    void FixedUpdate()
    {
        //get the direction of the player and move it

        if (movement.x != 0 && movement.y != 0)
        {
            if (canMove(new Vector2(movement.x, movement.y)))
            {
                rb.MovePosition(rb.position + new Vector2(movement.x, movement.y) * movSpeed * Time.fixedDeltaTime);
            }
        }
        else if (movement.x != 0)
        {
            if (canMove(new Vector2(movement.x, 0)))
            {
                rb.MovePosition(rb.position + movement * movSpeed * Time.fixedDeltaTime);
            }
        }
        else if (movement.y != 0)
        {
            if (canMove(new Vector2(0, movement.y)))
            {
                rb.MovePosition(rb.position + movement * movSpeed * Time.fixedDeltaTime);
            }
        }
    }

    private bool canMove(Vector2 dir)
    {
        // check the direction of the player and if the next tile is a wall or not 
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        if (hit.collider != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
