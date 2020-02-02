using UnityEngine;

// элемент инвентаря 
public class InventoryItem : MonoBehaviour
{
    // название вещи 
    public string itemName;
    // текстура для инвентаря 
    public Texture2D inventoryTexture;
    // префаб для сброса вещи 
    public GameObject prefabToDrop;
    // префаб для одевания 
    public GameObject prefabToEquip;

}