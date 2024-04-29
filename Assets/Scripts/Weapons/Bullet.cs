using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AttackArea
{
    public bool isDestroyed = false;
    private float timeTillDestroy;
    private float timeAlive = 0f;

    private int bulletDamage = 20;

    public Bullet(float timeTillDestroy, int damage,Sprite image,movementDirection dir)
    {
        this.icon = image;
        this.GetComponent<SpriteRenderer>().sprite = image;
        this.timeTillDestroy = timeTillDestroy;
        this.bulletDamage = damage;
        this.currentDirection = dir;
    }

    public void setBullet(Sprite image, movementDirection dir,int damage,float timeTillDestroy)
    {
        this.damage = damage;
        this.icon = image;
        this.GetComponent<SpriteRenderer>().sprite = image;
        this.currentDirection = dir;
        this.timeTillDestroy = timeTillDestroy;

        rotateBullet();
    }

    private void rotateBullet()
    {
        switch (this.getCurrentDirection())
        {
            case movementDirection.Up:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case movementDirection.Down:
                transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case movementDirection.Left:
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case movementDirection.Right:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;

            default:
                break;
        }
    }

    public void travel()
    {
        if (timeAlive >= timeTillDestroy)
        {
            isDestroyed = true;
        }
        timeAlive += Time.deltaTime;
        switch (this.getCurrentDirection())
        {
            case movementDirection.Up:
            //change only the x value of the position
                transform.position += 70 * Time.deltaTime * transform.right;
                break;
            case movementDirection.Down:
                transform.position -= -70 * Time.deltaTime * transform.right;
                break;
            case movementDirection.Left:
                transform.position -= -70 * Time.deltaTime * transform.right;
                break;
            case movementDirection.Right:
                transform.position += 70 * Time.deltaTime * transform.right;
                break;

            default:
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit!");
            other.gameObject.GetComponent<Enemy>().takeKnockBack(getDirectionOnCollision(other));
            other.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
        }
    }


}
