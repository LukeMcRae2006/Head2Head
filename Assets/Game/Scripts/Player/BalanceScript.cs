using UnityEngine;

public class BalanceScript : MonoBehaviour
{
    [SerializeField] private float targetRot;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force = 500;
    void Update()
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRot, force * Time.fixedDeltaTime));
    }
}
