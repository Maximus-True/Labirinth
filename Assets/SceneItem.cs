using UnityEngine;

// объект сцены, который можно подобрать 
public class SceneItem : MonoBehaviour
{
    // префаб для инвентаря 
    public InventoryItem prefab;

    // если кто-то вошел в триггер, то просим его поднять вещь 
    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.SendMessage("Equip", this);
    }

}