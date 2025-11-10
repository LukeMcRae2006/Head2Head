using UnityEngine;
using Photon.Pun;
using System.Numerics;
using Vector2 = UnityEngine.Vector2;
using Quaternion = UnityEngine.Quaternion;

public class SpawnPlayers : MonoBehaviour
{

    public GameObject playerPrefab;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 spawn = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerPrefab.name, spawn, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
