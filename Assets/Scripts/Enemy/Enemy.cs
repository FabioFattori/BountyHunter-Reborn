using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour{

    private int ID;

    
    private int damage;

    public EntityHealtBar entityHealtBar;
    private int speed;
    private int range;
    private int attackSpeed;
    private int attackRange;

    

    public int getID(){
        return ID;
    }

    public void setID(int id){
        this.ID = id;
    }

    public int getHealth(){
        return entityHealtBar.getMaxHealth();
    }

    public void setHealth(int health){
        entityHealtBar.setMaxHealth(health);
    }

    public int getDamage(){
        return damage;
    }

    public int getSpeed(){
        return speed;
    }

    public int getRange(){
        return range;
    }

    public int getAttackSpeed(){
        return attackSpeed;
    }

    public int getAttackRange(){
        return attackRange;
    }


    public void setDamage(int damage){
        this.damage = damage;
    }

    public void setSpeed(int speed){
        this.speed = speed;
    }

    public void setRange(int range){
        this.range = range;
    }

    public void setAttackSpeed(int attackSpeed){
        this.attackSpeed = attackSpeed;
    }

    public void setAttackRange(int attackRange){
        this.attackRange = attackRange;
    }

    public void TakeDamage(int damage){
        entityHealtBar.TakeDamage(damage);
    }

    public void takeKnockBack(Vector3 directionOfAttack){
        Debug.Log("Knockback in direction "+ directionOfAttack);
        //sum the direction of the attack to the current position of the enemy
        Vector3 target = this.transform.position + new Vector3(directionOfAttack.x*10, directionOfAttack.y * 10, 0);

        Debug.Log("Target: " + target);

        this.transform.position = Vector3.MoveTowards(this.transform.position, target, 1 );
    }

    public string toString(){
        return "ID: " + ID + " Health: " + entityHealtBar.getMaxHealth() + " Damage: " + damage + " Speed: " + speed + " Range: " + range + " AttackSpeed: " + attackSpeed + " AttackRange: " + attackRange;
    }
}