using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            Destroy(this.gameObject);
            activeWeapon.SwitchWeapon(weaponSO);
        }
    }
}
