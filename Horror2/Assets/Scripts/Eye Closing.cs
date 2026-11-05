using UnityEngine;

public class EyeClosing : MonoBehaviour
{
    public KeyCode eyeClose = KeyCode.C;
    public bool blunda = false;
    public Transform movementCheck; // checks if you're on the ground 
    public float stationaryCheckRadius = 0.01f; // groundcheck hitbox, the lesser the number the harder it gets to spam it to hover
    public LayerMask groundLayer; // whether the groundchecks sees it as ground or not
    private bool isStill = false; // in case we are on the ground or not




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        
    }

    // Update is called once per frame
    public void Update()
    {
        isStill = Physics2D.OverlapCircle(movementCheck.position, stationaryCheckRadius, groundLayer);
        
        if (Input.GetKey(eyeClose) && isStill)
        { blunda = true;
        }
    }
}
