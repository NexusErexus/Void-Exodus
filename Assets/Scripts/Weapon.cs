using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using Unity.Mathematics;

public class Weapon : MonoBehaviour
{
    [SerializeField] float rayMaxDistance = 10f;
    [SerializeField] InputActionReference fireReference;
    [SerializeField] private int pistolDamage;
    [SerializeField] private ParticleSystem pistolMuzzleFlash;
    [SerializeField] Animator animator;
    [SerializeField] GameObject hitVFXPrefab;
    //[SerializeField] Animator recoilAnimator;
    StarterAssetsInputs starterAssetsInputs;
    private const string PISTOL_SHOOT = "SHOOT";
    private const string PISTOL_RECOIL = "RECOIL";

    RaycastHit hit;
    
    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();

    }
    private void Start()
    {
        //animator = GetComponent<Animator>();
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
        
        
    }
    
    private void OnEnable()
    {
        fireReference.action.Enable(); //enable action map
        fireReference.action.started += OnFireAction;
    }
    private void OnDisable()
    {
        fireReference.action.Disable(); //disable action map
        fireReference.action.started -= OnFireAction;
    }
    public void OnFireAction(InputAction.CallbackContext ctx)
    {
        if (!starterAssetsInputs.shoot) return; //if player doesn't shoot, return from the method

        pistolMuzzleFlash.Play();

        Debug.Log("Shoot");
        animator.Play(PISTOL_SHOOT, 0, 0f);
        animator.Play(PISTOL_RECOIL, 1, 0f);
        starterAssetsInputs.ShootInput(false);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayMaxDistance))
        {
            //Quaternion VFXSparkAngle = personController.transform.rotation;
            var VFXToDelete = Instantiate(hitVFXPrefab, hit.point, Quaternion.LookRotation(hit.normal));
            Debug.Log(hit.point);
            Destroy(VFXToDelete, 5f);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(pistolDamage);
        }
        
    }



    
}
