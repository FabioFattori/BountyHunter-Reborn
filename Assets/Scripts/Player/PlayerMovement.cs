using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movSpeed = 5f;
    Vector2 movement;
    public Rigidbody2D rb;

    public movementDirection direction;

    //get the player health script
    public EntityHealtBar playerHealth;

    public loadTile map;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<EntityHealtBar>();
        direction = movementDirection.Down;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            // get the input from the player
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            checkMovementValidity(ref movement);
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }
    }

    private void checkMovementValidity(ref Vector2 movement){
        if(movement.x > 0){
            if(map.getBorderds()[2] < transform.position.x + movement.x){
                movement.x = 0;
            }
        }else if(movement.x < 0){
            if(map.getBorderds()[0] > transform.position.x + movement.x){
                movement.x = 0;
            }
        }

        if(movement.y > 0){
            if(map.getBorderds()[3] < transform.position.y + movement.y){
                movement.y = 0;
            }
        }else if(movement.y < 0){
            if(map.getBorderds()[1] > transform.position.y + movement.y){
                movement.y = 0;
            }
        }


    }

    void FixedUpdate()
    {
        //get the direction of the player and move it
        //get the animator 
        Animator animator = GetComponent<Animator>();

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


        if (movement.x > 0)
        {
            direction = movementDirection.Right;
            animator.SetFloat("movement", 1);
        }
        else if (movement.x < 0)
        {
            direction = movementDirection.Left;
            animator.SetFloat("movement", -1);
        }
        else if (movement.y > 0)
        {
            direction = movementDirection.Up;
            animator.SetFloat("movement", -2);
        }
        else if (movement.y < 0)
        {
            direction = movementDirection.Down;
            animator.SetFloat("movement", 2);
        }
        else
        {
            switch (direction)
            {
                case movementDirection.Up:
                    animator.SetFloat("movement", 6);
                    break;
                case movementDirection.Down:
                    animator.SetFloat("movement", 3);
                    break;
                case movementDirection.Left:
                    animator.SetFloat("movement", 4);
                    break;
                case movementDirection.Right:
                    animator.SetFloat("movement", 5);
                    break;
            }
        }
    }

    private bool canMove(Vector2 dir)
    {
        // check the direction of the player and if the next tile is a wall or not 
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        if (!hit.collider.name.Equals("Player") && !hit.collider.tag.Equals("Enemy"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Enemy")
        {
            //If the GameObject's tag matches the one you provide, output this message in the console
            playerHealth.TakeDamage(10);
            GetComponent<Teleporter>().cancelTeleport();
        }
    }
}
