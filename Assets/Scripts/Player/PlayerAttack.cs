using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject AttackArea=default;
    private bool isAttacking=false;

    private float attackTime=0.5f;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        AttackArea = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }

        if(isAttacking){
            timer += Time.deltaTime;
            if(timer >= attackTime){
                stopAttacking();
            }
        }
    }

    void Attack(){
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
