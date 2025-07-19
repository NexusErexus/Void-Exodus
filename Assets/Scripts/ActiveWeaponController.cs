using UnityEngine;

public class ActiveWeaponController : MonoBehaviour
{
    //Animator animator;
    //WeaponSO weaponSO;

    private void Awake()
    {
        //animator = GetComponentInChildren<Animator>();
    }
    public void ShootWeaponAnimation(WeaponSO weaponSO, Animator animator)
    {
        animator.Play(weaponSO.shootAnimName, 0, 0f);
    }
    public void RecoilWeaponAnimation(WeaponSO weaponSO, Animator animator)
    {
        animator.Play(weaponSO.recoilAnimName, 1, 0f);
    }
}
