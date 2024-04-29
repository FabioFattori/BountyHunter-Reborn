using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    protected movementDirection currentDirection;
    public Sprite icon;
    protected int damage = 1;
    protected float attackDuration = 1f;

    protected float timeTillNewAttack = 1f;


    public int getDamage()
    {
        return damage;
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    public movementDirection getCurrentDirection()
    {
        return currentDirection;
    }

    public void setCurrentDirection(movementDirection currentDirection)
    {
        this.currentDirection = currentDirection;
    }

    public float getAttackDuration()
    {
        return attackDuration;
    }

    public void setAttackDuration(float attackDuration)
    {
        this.attackDuration = attackDuration;
    }

    public float getTimeTillNewAttack()
    {
        return timeTillNewAttack;
    }

    public void setTimeTillNewAttack(float timeTillNewAttack)
    {
        this.timeTillNewAttack = timeTillNewAttack;
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

    protected Vector3 getDirectionOnCollision(Collision2D collision){
        Vector2 direction = collision.GetContact(0).point - (Vector2)transform.position;
        return direction.normalized;
    }
}
