using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject[] levels;

    private void Start()
    {

        ChangeLevel();
    }

    [PunRPC]
    public void ChangeLevel()
    {
        //check if there are any levels active rn
        GameObject currentLevel = GameObject.FindGameObjectWithTag("Level");
        if (currentLevel != null)
        {
            currentLevel.SetActive(false);
        }
        levels[Random.Range(0, levels.Length)].SetActive(true);
    }

}
