using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject AttackArea = default;
    private bool isAttacking = false;

    private float attackTime = 0f;

    private float attackCooldown = 0f;

    private float timeTillNextAttack = 0f;

    private float attackDuration = 0f;

    public bool getIsAttacking()
    {
        return isAttacking;
    }

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        AttackArea = transform.GetChild(transform.GetChildCount() - 1).gameObject;

        //get the attack time from the attack area
        attackTime = AttackArea.GetComponent<AttackArea>().getAttackDuration();

        timeTillNextAttack = AttackArea.GetComponent<AttackArea>().getTimeTillNewAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCooldown>=timeTillNextAttack)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Attack(movementDirection.Up);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Attack(movementDirection.Down);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Attack(movementDirection.Left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Attack(movementDirection.Right);
            }
        }

        attackCooldown += Time.deltaTime;

        if (isAttacking)
        {
            attackDuration += Time.deltaTime;
            if (attackDuration >= attackTime)
            {
                stopAttacking();
            }
        }
    }

    void Attack(movementDirection direction)
    {
        //reset attack cool down
        attackCooldown = 0f;

        switch (direction)
        {
            case movementDirection.Up:
                AttackArea.transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
                AttackArea.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case movementDirection.Down:
                AttackArea.transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
                AttackArea.transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            case movementDirection.Left:
                AttackArea.transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
                AttackArea.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case movementDirection.Right:
                AttackArea.transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
                AttackArea.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            default: break;
        }

        AttackArea.GetComponent<AttackArea>().setCurrentDirection(direction);

        if (!isAttacking)
        {
            isAttacking = true;
            AttackArea.SetActive(true);
        }

        this.GetComponent<Teleporter>().cancelTeleport();
    }

    public void stopAttacking()
    {
        isAttacking = false;
        //check if the attack area is a bow attack area
        if (AttackArea.GetComponent<BowAttackArea>() == null)
        {
            AttackArea.SetActive(false);
        }
        attackDuration = 0f;
    }

    public void setAttackArea(GameObject attackArea)
    {
        AttackArea = attackArea;
    }
}
