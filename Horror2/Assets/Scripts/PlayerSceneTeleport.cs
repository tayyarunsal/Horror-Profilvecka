using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneTeleporter : MonoBehaviour
{
    public static PlayerSceneTeleporter instance;

    private static int travelDirection = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // OnEnable runs when the object is turned on. We use it to subscribe to the scene load event.
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // OnDisable runs if the object is turned off or destroyed. Always unsubscribe to prevent memory leaks.
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // This method replaces Start(). It will trigger EVERY time a new scene finishes loading.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if we are the true instance, otherwise the duplicate might try to run this before dying
        if (instance != this) return;

        if (travelDirection == 1)
        {
            SpawnAtDoor("PreviousLevelChange");
        }
        else if (travelDirection == -1)
        {
            SpawnAtDoor("NextLevelChange");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NextLevelChange")
        {
            travelDirection = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.tag == "PreviousLevelChange")
        {
            travelDirection = -1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    private void SpawnAtDoor(string doorTag)
    {
        GameObject door = GameObject.FindGameObjectWithTag(doorTag);

        if (door != null)
        {
            Transform spawnPoint = door.transform.Find("SpawnPoint");

            if (spawnPoint != null)
            {
                transform.position = spawnPoint.position;
            }
            else
            {
                transform.position = door.transform.position;
            }
        }
    }
}