using UnityEngine;
using Photon.Pun;

public class Landmine : MonoBehaviour
{
    private PhotonView view;
    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    [PunRPC]
    private void Explode()
    {
        PhotonNetwork.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        IDamageable dmg = col.gameObject.GetComponent<IDamageable>();
        if (dmg != null)
        {
            dmg.TakeDamage(1);
            view.RPC("Explode", RpcTarget.All);
        }

    }
}
