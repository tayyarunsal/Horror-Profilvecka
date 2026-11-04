using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Lights : MonoBehaviour
{

    [SerializeField]
    public float sanityLoss = 1;

    [SerializeField]
    public float sanityGain = 1;

    [SerializeField]
    public float totalPlayerSanity = 4;

    [SerializeField]
    public bool active;

    [SerializeField]
    GameObject lightPreFab;

    public float nextChange;
    public float changeTimer;

    GameObject newGameObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextChange = Random.Range(2f, 7f);
    }

    // Update is called once per frame
    void Update()
    {

        changeTimer += Time.deltaTime;
        if (changeTimer >= nextChange)
        {
            active = !active;
            changeTimer = 0f;

            nextChange = Random.Range(2f, 7f);
        }


        if (active == true && newGameObject == null)
        {
            newGameObject = Instantiate(lightPreFab, new Vector3(0, -3, 0), Quaternion.identity);
        }
        else if (active == false && newGameObject != null)
        {
            Destroy(newGameObject);
            newGameObject = null;
        }


    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player")) //check if the collided object has the tag "EnemyBeam"
        {
            totalPlayerSanity += sanityGain;
        }
    }
}
