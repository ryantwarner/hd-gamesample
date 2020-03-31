using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class GameInventoryPickup : MonoBehaviour
{
    public string m_InventoryItemReference;
    
    void Awake()
    {
        
        if (m_InventoryItemReference == null) GameObject.Destroy(this);
        }

    public void AddItem()
    {
        GameInventory.Instance.AddItem(m_InventoryItemReference);
    }
}
