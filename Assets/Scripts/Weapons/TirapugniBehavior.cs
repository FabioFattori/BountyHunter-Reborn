
using UnityEngine;
public class Tirapugni : MeleeWeapons
{

    public Tirapugni()
    {
        damage = 10;
        range = 1.5f;
        timerToAttack = 1f;
    }

    public override void Attack(movementDirection direction, GameObject attackArea, Rigidbody2D playerRB)
    {

        if (canAttack())
        {
            attacking = true;
            
            //get the transform of the DamagingArea
            Rigidbody2D damagingArea = attackArea.GetComponent<Rigidbody2D>();
            Vector2 damagingAreaPosition = damagingArea.position;
            switch (direction)
            {
                case movementDirection.Up:
                    damagingAreaPosition = new Vector2(playerRB.position.x, playerRB.position.y + range);
                    break;
                case movementDirection.Down:
                    damagingAreaPosition = new Vector2(playerRB.position.x, playerRB.position.y - range);
                    break;
                case movementDirection.Right:
                    damagingAreaPosition = new Vector2(playerRB.position.x + range, playerRB.position.y);
                    break;
                case movementDirection.Left:
                    damagingAreaPosition = new Vector2(playerRB.position.x - range, playerRB.position.y);
                    break;
                default:
                    Debug.Log("direction not found");
                    break;
            }

            damagingArea.velocity = damagingAreaPosition;
        }
    }
}
