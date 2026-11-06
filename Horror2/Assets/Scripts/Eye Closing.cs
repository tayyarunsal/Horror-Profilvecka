using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class EyeClosing : MonoBehaviour
{
    public KeyCode eyeClose = KeyCode.C;
    public bool blunda = false;
    private moemvment3 motion;
    private Timer Timerson;
    private GameObject monster;
    public float Timing;

    [SerializeField]
    GameObject Prefab;

    void Start()
    {
        motion = GetComponentInParent<moemvment3>();
    }


    // Update is called once per frame
    public void Update()
    {
        monster = GameObject.FindWithTag("Monster");
      
        
        if (Input.GetKey(eyeClose))
        { blunda = true;
            
        }
        
        if (blunda == true)
        {
            
           
            Destroy(monster); //originally, you were supposed to stand still when closing your eyes, but we have 25 mins left. "motion.moveSpeed = 0f;" and "moiton.jumpForce = 0f;"
        }
    }
    
}