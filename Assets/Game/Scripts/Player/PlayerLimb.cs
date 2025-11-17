using Photon.Pun;
using UnityEngine;

public class PlayerLimb : MonoBehaviour, IDamageable
{
    public int limbHealth;
    [SerializeField] private GameObject destroyEffect;
    private PhotonView photonView;
    void Awake()
    {
        photonView = GetComponent<PhotonView>();

    }

    [PunRPC]
    public void TakeDamage(int Damage)
    {

        limbHealth -= Damage;
        if (limbHealth <= 0)
        {
            if (destroyEffect != null)
            {
                PhotonNetwork.Instantiate(destroyEffect.name, transform.position, transform.rotation);
            }
            photonView.RPC("Die", RpcTarget.All);
        }
    }

    [PunRPC]
    void Die()
    {
        Destroy(gameObject);
    }
}
