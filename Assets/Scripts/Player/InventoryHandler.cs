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
            newSlot.transform.GetComponent<UnityEngine.UI.Image>().sprite = inventory.inventory[i].icon;
            int j = i;
            newSlot.GetComponent<Button>().onClick.AddListener(()=> { inventory.EquipIndex(j); });
        }



        GameObject.Find("ItemImage").gameObject.GetComponent<UnityEngine.UI.Image>().sprite = inventory.AttackArea.icon;
    }
}
