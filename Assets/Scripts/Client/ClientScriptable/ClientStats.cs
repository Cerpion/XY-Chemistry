using UnityEngine;

[CreateAssetMenu(fileName = "ClientStats", menuName = "Client/Client", order = 0)]
public class ClientStats : ScriptableObject
{
    public Sprite Walk;
    public Sprite Talk;
    public AudioClip Voice;
    public ClientMovement Prefab;
}