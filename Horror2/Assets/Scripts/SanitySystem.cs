using UnityEngine;
using TMPro;

public class SanitySystem : MonoBehaviour
{

    public int sanity = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sanity >= 75)
        {

        }
        else if (sanity >= 50)
        { //scary-erx
        }
        else if (sanity >= 25)
        { //scary-est
        }
        else if (sanity >= 0)
        { //dead
        }
    }
}
