using UnityEngine;
class DamagingArea : MonoBehaviour
{
    private int damage = 0;
    
    private void Start()
    {
        //get the damage from the weapon
        damage = GetComponentInParent<PlayerAttack>().w.damage;
    }
    
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.GetComponent<EntityHealtBar>() != null)
        {
            collider2D.GetComponent<EntityHealtBar>().TakeDamage(damage);
        }
    }
}
