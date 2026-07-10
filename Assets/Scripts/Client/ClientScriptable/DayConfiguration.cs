using UnityEditor.PackageManager;
using UnityEngine;

[CreateAssetMenu(fileName = "DayConfiguration", menuName = "Days/DayConfiguration", order = 0)]
public class DayConfiguration : ScriptableObject
{
    public Day[] Day;
}

[System.Serializable]
public class ClientDay
{
    public ClientData ClientStats;
    public ItemData Order;
    public float ClientTime;
}
