using UnityEngine;
public abstract class MeleeWeapons
{

    public bool attacking = false;
    public int damage;
    public float range;
    public float timerToAttack;

    public float timer = 0f;

    public bool canAttack()
    {

        if (attacking)
        {
            if (timer >= timerToAttack)
            {
                timer = 0;
                return true;
            }
            return false;
        }
        return true;

    }

    public void runEachFrame()
    {
        timer += Time.deltaTime;
        if (attacking && timer >= timerToAttack)
        {
            timer = 0;
            attacking = false;
        }
    }

    public virtual void Attack(movementDirection direction, GameObject attackArea, Rigidbody2D playerRB)
    {

        if (canAttack())
        {
            //do the attack
            Debug.Log("melee attack to direction => " + direction.ToString());
            attacking = true;
        }
    }


}
