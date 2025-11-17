using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class Gun : MonoBehaviour
{
    [SerializeField] private InputActionReference fireAction;
    [SerializeField] private GameObject bulletObj;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private float timeBtwShotSetter = 0.5f;
    private float timeBtwShot = 0;

    private PhotonView view;
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        //check if game is ready
        if (GameManager.gameState != GameManager.GameState.WaitingForPlayers)
        {
            if (view.IsMine)
            {
                if (timeBtwShot <= 0)
                {
                    if (fireAction.action.IsPressed())
                    {
                        //shoot
                        PhotonNetwork.Instantiate(bulletObj.name, bulletPoint.position, bulletPoint.rotation);
                        timeBtwShot = timeBtwShotSetter;

                    }
                }
                else
                {
                    timeBtwShot -= Time.deltaTime;
                }
            }
        }
    }
}
