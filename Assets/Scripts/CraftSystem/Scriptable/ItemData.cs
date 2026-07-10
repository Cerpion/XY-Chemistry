using UnityEngine;

[CreateAssetMenu(fileName = "ItemStats", menuName = "Item/ItemStats", order = 1)]
public class ItemData : ScriptableObject
{
   public ItemID ItemID;
   public string ID => ItemID.ID;

   public Sprite Icon;
   public Color IconColor;
   public string Name;
   public GameObject Prefab;
}
