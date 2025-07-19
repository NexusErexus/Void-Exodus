using Cinemachine;
using StarterAssets;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayerAfterFall : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] CinemachineVirtualCamera virtualCamera;


    public static event Action<FirstPersonController> OnPlayerSpawned;

    void RespawnPlayer()
    {
        GameObject newPlayer = Instantiate(player, player.transform.position, player.transform.rotation); //respawn player
        var playerController = newPlayer.GetComponent<FirstPersonController>(); //update player's component
        virtualCamera.m_Follow = newPlayer.transform.GetChild(0); //reassign camera to player's camera root
        OnPlayerSpawned?.Invoke(playerController); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Invoke(nameof(RespawnPlayer), 0.05f);
        } 
    }
}
