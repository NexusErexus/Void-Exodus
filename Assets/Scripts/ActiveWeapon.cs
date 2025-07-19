using UnityEngine;
using StarterAssets;
using Cysharp.Threading.Tasks;
using System;
using System.Xml.Schema;

public class ActiveWeapon : MonoBehaviour
{

    [SerializeField] WeaponSO weaponSO;
    Animator animator;
    Weapon currentWeapon;
    ActiveWeaponController controller;
    //[SerializeField] Animator recoilAnimator;
    StarterAssetsInputs starterAssetsInputs;
    //private const string PISTOL_SHOOT = "SHOOT";
    //private const string PISTOL_RECOIL = "RECOIL";
    private bool isShooting = false;

    //RaycastHit hit;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponentInChildren<Animator>();

    }
    private void Start()
    {
        //animator = GetComponent<Animator>();
        currentWeapon = GetComponentInChildren<Weapon>();
        currentWeapon.SetWeaponSO(weaponSO);

        controller = GetComponentInChildren<ActiveWeaponController>();
    }
    // Update is called once per frame
    void Update()
    {
        /*if (starterAssetsInputs.shoot)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayMaxDistance))
            {
                Debug.Log(hit.collider.name);
                starterAssetsInputs.ShootInput(false);
            }
        }*/
        if (starterAssetsInputs.shoot)
        {
            HandleShoot().Forget();
        }

        
    }


    public async UniTaskVoid HandleShoot()
    {
        
        //if (!starterAssetsInputs.shoot || isShooting) return; //if player doesn't shoot, return from the method
        if (currentWeapon == null || isShooting) return;
        
        isShooting = true;
        Debug.Log(controller);
        
        controller.ShootWeaponAnimation(weaponSO, animator);
        controller.RecoilWeaponAnimation(weaponSO, animator);
        
        //animator.Play(PISTOL_SHOOT, 0, 0f);
        //animator.Play(PISTOL_RECOIL, 1, 0f);
        

        currentWeapon.Fire(weaponSO);
        //currentWeapon.Unsubscribe();
        await UniTask.Delay(TimeSpan.FromSeconds(weaponSO.fireRate), cancellationToken: this.GetCancellationTokenOnDestroy());
        //currentWeapon.Subscribe();

        isShooting = false;
        if (!weaponSO.isAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }

    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }
        
        Debug.Log(currentWeapon.name);
        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO;
        animator = newWeapon.GetComponentInChildren<Animator>(); //update animator for new weapon
        Debug.Log("done");

    }


}
