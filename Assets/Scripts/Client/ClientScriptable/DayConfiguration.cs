using UnityEditor.PackageManager;
using UnityEngine;

[CreateAssetMenu(fileName = "DayConfiguration", menuName = "Days/DayConfiguration", order = 0)]
public class DayConfiguration : ScriptableObject
{
    public Day[] Day;
}

[System.Serializable]
public class Day : ScriptableObject
{
    public int DayNumber;
    public Recipe[] Recipes;
    public ItemID[] ItemsDay;
    public ClientDay[] ClientDay;
}

[System.Serializable]
public class ClientDay : ScriptableObject
{
    public ClientStats ClientStats;
    public ItemID Order;
}
