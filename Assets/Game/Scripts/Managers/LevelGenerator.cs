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
        level = GameObject.FindGameObjectWithTag("Level");
        if (level == null)
        {
            //this means there is no level yet
            level = levels[Random.Range(0, levels.Length)];
            level.SetActive(true);
        }
        //check if there are any levels active rn

    }

}
