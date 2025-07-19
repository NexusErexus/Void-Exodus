using StarterAssets;
using UnityEngine;
using Cinemachine.Utility;
using Cinemachine;
using UnityEngine.SceneManagement;

public class SpawnPlayerAfterFall : MonoBehaviour
{
    [SerializeField] GameObject player;
    string getCurrentSceneIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        string getCurrentSceneIndex = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetIndexScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void ReloadCurrentScene()
    {
        int inxdexOfCurrentScene = GetIndexScene();
        SceneManager.LoadScene(inxdexOfCurrentScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            /*Destroy(other.gameObject);
            Instantiate(player, player.transform.position, player.transform.rotation);

            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            Transform newCameraFollow = player.transform;
            virtualCamera.m_Follow = newCameraFollow;*/
            ReloadCurrentScene();
        }
            
    }
}
