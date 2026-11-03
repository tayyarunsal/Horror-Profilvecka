using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Lights : MonoBehaviour
{

    [SerializeField]
    float lightFlickerTime = 1;

    [SerializeField]
    float sanityLoss = 1;

    [SerializeField]
    float sanityGain = 1;

    [SerializeField]
    float totalPlayerSanity = 98;

    [SerializeField]
    bool active;

    [SerializeField]
    GameObject lightPreFab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (active == true)
        {
            GameObject newGameObject = Instantiate(lightPreFab, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (active == false)
        {
            Destroy(lightPreFab);
        }




            void OnTriggerEnter2D(Collider2D otherCollider)
            {
                if (otherCollider.CompareTag("Player")) //check if the collided object has the tag "EnemyBeam"
                {
                    totalPlayerSanity += sanityGain;
                }
            }
    }
}
