using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    //[SerializeField] InputActionReference fireReference;
    [SerializeField] private ParticleSystem pistolMuzzleFlash;
    [SerializeField] float rayMaxDistance = 10f;
    WeaponSO weaponSO;

    public void SetWeaponSO(WeaponSO newWeaponSO)
    {
        weaponSO = newWeaponSO;
    }
    /*private void OnEnable()
    {
        Subscribe();
    }
    private void OnDisable()
    {
        Unsubscribe();
    }
    public void Subscribe()
    {
        fireReference.action.Enable(); //enable action map
        fireReference.action.performed += OnFireAction;
    }
    public void Unsubscribe()
    {
        fireReference.action.Disable(); //disable action map
        fireReference.action.performed -= OnFireAction;
    }
    public void OnFireAction(InputAction.CallbackContext ctx)
    {
        Fire(weaponSO);
    }*/

    public void Fire(WeaponSO weaponSO)
    {
        RaycastHit hit;
        pistolMuzzleFlash.Play();

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayMaxDistance))
        {
            var VFXToDelete = Instantiate(weaponSO.hitVFXPrefab, hit.point, Quaternion.LookRotation(hit.normal));
            Debug.Log(hit.point);
            Destroy(VFXToDelete, 5f);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.damage);
        }
    }

}
