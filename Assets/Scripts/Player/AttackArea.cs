using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 20;

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
