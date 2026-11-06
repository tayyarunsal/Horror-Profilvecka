using UnityEngine;

public class wallision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Surface")) //checks if it's a Surface
        {
            transform.position =
               new Vector3(transform.position.x,
               Mathf.Clamp(transform.position.y, -3.767f, 3.767f), 0); //allows our player to stand on surfaces without phasing through the ground. Is the extra script necessary? probably not. Do I want to risk breaking the code for the movemn? no. yes i do.
        }
    }
}