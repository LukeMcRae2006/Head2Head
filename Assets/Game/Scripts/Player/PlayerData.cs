using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Player Data")]
public class PlayerData : ScriptableObject
{
    public string playerName = "Player";
    public int health = 1;
    public float playerSpeed = 10f;
    public int playerScore = 0;

}