using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject AttackArea=default;
    private bool isAttacking=false;

    private float attackTime=0f;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        AttackArea = transform.GetChild(1).gameObject;

        //get the attack time from the attack area
        attackTime = AttackArea.GetComponent<AttackArea>().getTimeToAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            Attack(movementDirection.Up);
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
            Attack(movementDirection.Down);
        }else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            Attack(movementDirection.Left);
        }else if(Input.GetKeyDown(KeyCode.RightArrow)){
            Attack(movementDirection.Right);
        }

        if(isAttacking){
            timer += Time.deltaTime;
            if(timer >= attackTime){
                stopAttacking();
            }
        }
    }

    void Attack(movementDirection direction){
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

        if(!isAttacking){
            isAttacking=true;
            AttackArea.SetActive(true);
        }
    }

    public void stopAttacking(){
        isAttacking=false;
        AttackArea.SetActive(false);
        timer = 0f;
    }
}
