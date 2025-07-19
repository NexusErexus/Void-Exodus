using StarterAssets;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        SpawnPlayerAfterFall.OnPlayerSpawned += HandlePlayerSpawned;
    }

    private void OnDisable()
    {
        SpawnPlayerAfterFall.OnPlayerSpawned -= HandlePlayerSpawned;
    }

    void HandlePlayerSpawned(FirstPersonController newPlayer)
    {
        player = newPlayer;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && agent.enabled)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}
