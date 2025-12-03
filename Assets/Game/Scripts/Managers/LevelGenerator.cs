using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LevelGenerator : MonoBehaviourPun
{
    public GameObject[] landLevels;

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            int index = Random.Range(0, landLevels.Length);
            photonView.RPC("RPC_ActivateLevel", RpcTarget.AllBuffered, index);
        }
    }



    [PunRPC]
    public void RPC_ActivateLevel(int index)
    {
        for (int i = 0; i < landLevels.Length; i++)
            landLevels[i].SetActive(i == index);

        Debug.Log("Activated level index: " + index);
    }
}