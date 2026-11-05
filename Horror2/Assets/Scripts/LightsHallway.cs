using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class LightsHallway : MonoBehaviour
{
    public float sanityLoss = 20;
    public float sanityGain = 25;
    public bool active;

    [SerializeField]
    GameObject lightPreFab;

    [SerializeField]
    GameObject BackgroundOfLight;


    [SerializeField]
    GameObject DoorOfLight;

    public float nextChange;
    public float changeTimer;

    private SanitySystem sanitySystem;
    GameObject newGameObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sanitySystem = FindFirstObjectByType<SanitySystem>();

        if (sanitySystem == null)
        {
            Debug.LogError("no find SS");
        }

        nextChange = Random.Range(2f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        changeTimer += Time.deltaTime;
        if (changeTimer >= nextChange)
        {
            active = !active;
            changeTimer = 0f;

            nextChange = Random.Range(2f, 10f);
        }

        if (active == true && newGameObject == null)
        {
            newGameObject = Instantiate(lightPreFab, new Vector3(0, -6, 0), Quaternion.identity);
            BackgroundOfLight.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            DoorOfLight.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        else if (active == false && newGameObject != null)
        {
            Destroy(newGameObject);
            newGameObject = null;
            BackgroundOfLight.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
            DoorOfLight.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player")) //check if the collided object has the tag "EnemyBeam" (or Player)
        {
            if (sanitySystem == null) // FIXED: added == instead of =
            {
                Debug.LogError("no sanity");
            }

            if (active)
            {
                sanitySystem.ChangeSanity(sanityGain * Time.deltaTime);
            }
            else
            {
                sanitySystem.ChangeSanity(-sanityLoss * Time.deltaTime);
            }
        }
    }
}