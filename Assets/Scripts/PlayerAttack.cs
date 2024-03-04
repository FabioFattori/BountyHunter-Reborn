using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public MeleeWeapons w;
    public GameObject attackArea = default;
    private movementDirection direction;
    // Start is called before the first frame update
    void Start()
    {
        w = WeaponFactory.createTirapugni();

        //get the direction of the player from the movement script
        direction = GetComponent<PlayerMovement>().direction;
    }

    // Update is called once per frame
    void Update()
    {
        direction = GetComponent<PlayerMovement>().direction;

        w.runEachFrame();


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            w.Attack(movementDirection.Up, attackArea, GetComponent<PlayerMovement>().rb);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            w.Attack(movementDirection.Down, attackArea, GetComponent<PlayerMovement>().rb);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            w.Attack(movementDirection.Right, attackArea, GetComponent<PlayerMovement>().rb);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            w.Attack(movementDirection.Left, attackArea, GetComponent<PlayerMovement>().rb);
        }



        if (w.attacking)
        {
            attackArea.SetActive(true);
        }
        else
        {
            attackArea.SetActive(false);
        }
    }

    public void setWeapon(MeleeWeapons weapon)
    {
        w = weapon;
    }
}
