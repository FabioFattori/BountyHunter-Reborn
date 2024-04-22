using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    protected int damage = 1;
    protected float timeToAttack = 1f;


    public int getDamage()
    {
        return damage;
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    public float getTimeToAttack()
    {
        return timeToAttack;
    }

    public void setTimeToAttack(float timeToAttack)
    {
        this.timeToAttack = timeToAttack;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject.Find("Player").GetComponent<Rigidbody2D>().centerOfMass = Vector2.zero;
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit!");
            other.gameObject.GetComponent<Enemy>().takeKnockBack(getDirectionOnCollision(other));
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    private Vector3 getDirectionOnCollision(Collision2D collision){
        Vector2 direction = collision.GetContact(0).point - (Vector2)transform.position;
        return direction.normalized;
    }
}
