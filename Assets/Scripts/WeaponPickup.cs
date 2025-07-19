using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float positionPeriod = 10f;
    [SerializeField] float rotationPeriod = 30f;
    
    Vector3 startingPosition;
    
    const float TAU_VALUE = Mathf.PI * 2;
    float movementFactor;
    private void Start()
    {
        startingPosition = transform.position;
    }

    public void Update()
    {

        MoveWeapon();
        RotateWeapon();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            Destroy(this.gameObject);
            activeWeapon.SwitchWeapon(weaponSO);
        }
    }

    public void MoveWeapon()
    {
        if (positionPeriod <= Mathf.Epsilon) return;
        
        float cycles = Time.time / positionPeriod;
        float RawSinWave = Mathf.Sin(cycles * TAU_VALUE);
        movementFactor = (RawSinWave + 1f) / 2f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
    public void RotateWeapon()
    {
        transform.Rotate(rotationPeriod * Time.deltaTime * Vector3.up);
    }
}
