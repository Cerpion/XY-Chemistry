using UnityEngine;

[CreateAssetMenu(fileName = "ClientStats", menuName = "Client/Client", order = 0)]
public class ClientData : ScriptableObject
{
    public Sprite Walk;
    public Sprite Talk;
    public AudioClip Voice;
    public ClientMovement Prefab;
}