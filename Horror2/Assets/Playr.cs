using UnityEngine;

public class Playr : MonoBehaviour
{
    [SerializeField]
    public float speed = 3f;
    [SerializeField]
    KeyCode jump = KeyCode.Space;
    [SerializeField]
    KeyCode crouch = KeyCode.S;
    [SerializeField]
    KeyCode left = KeyCode.A;
    [SerializeField]
    KeyCode right = KeyCode.D;
    [SerializeField]
    public int sanity = 100;
    
    












    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(jump)) //MAKE THE JUMP ACTUALLY JUMP
        {
            transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
        else if (Input.GetKey(crouch))
        {
            transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime; //REMOVE AND MAKE IT CROUCH
        }
        if (Input.GetKey(left))
        {
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        else if (Input.GetKey(right))
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }


        if (sanity < 0)
        { //FILL

        }

    }
}
