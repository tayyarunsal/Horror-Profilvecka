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
            instance = this; //the player which is the parent of this script.
            DontDestroyOnLoad(gameObject); //makes sure our player and the objects inside of it doesn't get destroyed.
        }
        else
        {
            Destroy(gameObject); //if it exists dupes somehow.
        }
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; //loads our next level by +1, depending on the previous door we entered.
    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; //loads our next level by -1, depending on the previous door we entered.
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (travelDirection == 1) //if the direction is going up/front.
        {
            SpawnAtDoor("PreviousLevelChange"); //then spawn at the PreviousLevelChange
        }
        else if (travelDirection == -1) //if the direction is going down/end
        {
            SpawnAtDoor("NextLevelChange"); //then spawn at the NextLevelChange
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