using UnityEditor.Experimental.GraphView;

using UnityEngine;


public class LightZone : MonoBehaviour

{

    private SanitySystem sanitySystem;



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {

        sanitySystem = FindFirstObjectByType<SanitySystem>();

    }


    // Update is called once per frame

    void Update()

    {



    }



    void OnTriggerEnter2D(Collider2D other)

    {

        if (other.CompareTag("Player"))

        {

            Debug.Log("Player entered");


            if (sanitySystem != null)

                Debug.Log("player current");

            {

                sanitySystem.SetInLight(true);

            }

        }

    }


    void OnTriggerExit2D(Collider2D other)

    {

        if (other.CompareTag("Player"))

        {

            Debug.Log("Player exited");


            if (sanitySystem != null)

            {

                sanitySystem.SetInLight(false);

            }

        }

    }


    void OnDisable()

    {

        if (sanitySystem != null)

        {

            sanitySystem.SetInLight(false);

        }

    }


}