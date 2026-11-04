using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public SpriteRenderer doorRenderer;

    public Sprite closedDoor;
    public Sprite openDoor;
    [SerializeField]
    GameObject doorcollision;

    private bool isOpen = false;

    void Start()
    {
        doorRenderer.sprite = closedDoor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            isOpen = true;
            Destroy(gameObject);
            doorRenderer.sprite = openDoor;
            transform.position = new Vector3(10f, -1, 0);
            Destroy(doorcollision);
        }
    }
}
