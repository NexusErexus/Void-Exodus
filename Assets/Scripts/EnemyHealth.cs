using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int CurrentHealth {  get; private set; }
    
    [SerializeField] private int enemyHealth;
    //private int currentHealth;
    private void Awake()
    {
        CurrentHealth = enemyHealth;
        Debug.Log(CurrentHealth);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
