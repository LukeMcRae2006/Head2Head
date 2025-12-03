using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject[] levels;

    private GameObject level;

    private void Start()
    {

        ChangeLevel();
    }

    [PunRPC]
    public void ChangeLevel()
    {
        if (level == null)
        {
            //check if there are any levels active rn
            level = levels[Random.Range(0, levels.Length)];
            level.SetActive(true);
        }
    }

}
