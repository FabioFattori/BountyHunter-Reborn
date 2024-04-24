using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // List of AttackArea objects prefabs
    [SerializeField]
    public List<AttackArea> inventory = new List<AttackArea>();

    private AttackArea currentWeapon;

    public AttackArea AttackArea
    {
        get
        {
            return currentWeapon;
        }

        set
        {
            this.currentWeapon = value;
        }
    }

    public void EquipIndex(int index)
    {
        Debug.Log("Equipping weapon at index: " + index);
        if (index < 0 || index >= inventory.Count)
        {
            return;
        }

        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }

        currentWeapon = Instantiate(inventory[index]);
        currentWeapon.transform.parent = transform;
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localRotation = Quaternion.identity;
        currentWeapon.gameObject.SetActive(false);
        this.GetComponent<PlayerAttack>().setAttackArea(currentWeapon.gameObject);
        Debug.Log("Equipped weapon: " + currentWeapon.name);
    }   

    private void Start()
    {
        if(inventory.Count > 0)
        {
            EquipIndex(0);
        }
    }


}
