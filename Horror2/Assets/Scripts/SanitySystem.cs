using UnityEngine;

public class SanitySystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sanity >= 75)
        { //scary
        }
        else if (sanity >= 50)
        { //scary-er
        }
        else if (sanity >= 25)
        { //scary-est
        }
        else if (sanity >= 0)
        { //dead
        }
    }
}
