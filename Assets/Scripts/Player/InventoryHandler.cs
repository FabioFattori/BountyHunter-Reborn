using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
    private Inventory inventory;
    public GameObject inventoryMenu;

    public GameObject inventorySlotPrefab;

    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        inventoryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory")){
            isOpen = !isOpen;
            inventoryMenu.SetActive(isOpen);

            Time.timeScale = isOpen ? 0 : 1;
            if(isOpen){
                populateInventory();
            }
        }
    }

    private void populateInventory(){
        //clear the inventory menu
        foreach(Transform child in inventoryMenu.transform.GetChild(0)){
            Destroy(child.gameObject);
        }
        GameObject slots = inventoryMenu.transform.GetChild(0).gameObject;
        for (int i = 0; i < inventory.inventory.Count; i++)
        {
            //set the image of the slot to the image of the attack area
            var newSlot = Instantiate(inventorySlotPrefab, slots.transform);
            newSlot.transform.GetComponent<Image>().sprite = inventory.inventory[i].icon;
            int j = i;
            newSlot.GetComponent<Button>().onClick.AddListener(()=> { changeWeapon(j); });
        }



        if(GameObject.Find("Player").GetComponent<Inventory>().AttackArea != null){
            changeWeapon(0);
        }
    }

    private void changeWeapon(int index){
        if(inventory.AttackArea is BowAttackArea){
            //destroy all bullets
            foreach (var bullet in ((BowAttackArea)GameObject.Find("Player").GetComponent<Inventory>().AttackArea).getBullets())
            {
                Destroy(bullet);
            }   
        }
        
        inventory.EquipIndex(index);
        GameObject.Find("ItemImage").GetComponent<Image>().sprite = inventory.AttackArea.icon;

        
    }
}
