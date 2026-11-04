using UnityEngine;

public class wallision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Surface"))
        {
            transform.position =
               new Vector3(transform.position.x,
               Mathf.Clamp(transform.position.y, -3.767f, 3.767f), 0); //allows our player to stand on surfaces without phasing through the ground. Is the extra script necessary? probably not. Do I want to risk breaking the code for the movemn? no.
        }
    }
}
