using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHands : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Camera mainCamera;
    public int SelectedWeapon = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private InputActionReference scroll;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0f;

        // Direction from player to mouse
        Vector3 dir = mousePos - player.position;

        // Determine if player should face left or right
        if (dir.x >= 0)
            player.localEulerAngles = Vector3.zero; // facing right
        else
            player.localEulerAngles = new Vector3(0, 180, 0); // facing left

        // Gun local direction relative to player
        Vector3 localDir = player.InverseTransformPoint(mousePos) - player.InverseTransformPoint(player.position);

        // Angle in local space
        float angle = Mathf.Atan2(localDir.y, localDir.x) * Mathf.Rad2Deg;

        // Clamp angle between -90 and 90
        angle = Mathf.Clamp(angle, -90f, 90f);

        // Apply rotation
        transform.localEulerAngles = new Vector3(0, 0, angle);
        SwitchWeapons();
    }

    void SwitchWeapons()
    {
        int previousSelectedWeapon = SelectedWeapon;
        if (scroll.action.ReadValue<Vector2>().y > 0f)
        {
            if (SelectedWeapon >= transform.childCount - 1)
            {
                SelectedWeapon = 0;
            }
            else
            {
                SelectedWeapon++;
            }

        }
        else if (scroll.action.ReadValue<Vector2>().y < 0f)
        {
            if (SelectedWeapon <= 0)
            {
                SelectedWeapon = transform.childCount - 1;
            }
            else
            {
                SelectedWeapon--;
            }
        }






        if (previousSelectedWeapon != SelectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {

            if (i == SelectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

}

