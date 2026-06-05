using UnityEngine;
using System;


public class InventorySystem : MonoBehaviour
{
    void Start()
    {
        string[] inventory = new string[]
        {
            "Sword",
            "Shield",
            "Mace",
            "Knife",
            "Spear"
        };

        Debug.Log("==== Player Inventory ====");
        for (int i = 0; i < inventory.Length; i++)
        {
            Debug.Log("Slot " + i + ": " + inventory[i]);
        }

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == "Sword")
            {
                UnityEngine.Debug.Log("Sword is found in slot " + i);
            }
        }
    }
}
