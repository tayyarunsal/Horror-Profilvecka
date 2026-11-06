using UnityEngine;

public class DoorSwitch2 : MonoBehaviour
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
            doorRenderer.sprite = openDoor;
            transform.position = new Vector3(31f, -2, 0);
            Destroy(doorcollision);
        }
    }
}
