using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPrefab;
    public float damage = 3;
    public float fireRate = .3f;
    public GameObject hitVFXPrefab;
    public bool isAutomatic = false;

    public string shootAnimName;
    public string recoilAnimName;
}
