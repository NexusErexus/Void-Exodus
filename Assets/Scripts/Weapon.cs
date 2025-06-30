using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    [SerializeField] float rayMaxDistance = 10f;
    [SerializeField] InputActionReference fireReference;
    [SerializeField] private int pistolDamage;
    StarterAssetsInputs starterAssetsInputs;

    RaycastHit hit;
    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
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
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayMaxDistance))
            {
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                enemyHealth?.TakeDamage(pistolDamage);
                starterAssetsInputs.ShootInput(false);
            }
        }
    }



    
}
