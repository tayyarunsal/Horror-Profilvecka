using UnityEngine;
using UnityEngine.UI;

public class SanitySystem : MonoBehaviour
{
    public int sanity = 100;

    public Image sanityBar;
    public Image faceImage;

    public Sprite sanity100;
    public Sprite sanity75;
    public Sprite sanity50;
    public Sprite sanity25;
    public Sprite sanity0;

    public Sprite face100;
    public Sprite face75;
    public Sprite face50;
    public Sprite face25;
    public Sprite face0;

    public float sanityChangeSpeed = 5f;

    void Start()
    {
        UpdateSanity();
    }

    void Update()
    {
        if (IsInDarkness())
        {
            sanity -= Mathf.RoundToInt(sanityChangeSpeed * Time.deltaTime);
        }
        else
        {
            sanity += Mathf.RoundToInt(sanityChangeSpeed * Time.deltaTime);
        }

        // Sanity kan aldrig vara lägre än 0 eller högre än 100
        sanity = Mathf.Clamp(sanity, 0, 100);

        UpdateSanity();
    }

    // DENNA FUNKTION ANVÄNDS AV MONSTRET
    public void LoseSanity(int amount)
    {
        sanity -= amount;

        // Se till att sanity aldrig går under 0
        sanity = Mathf.Clamp(sanity, 0, 100);

        UpdateSanity();
    }

    bool IsInDarkness()
    {
        // true = mörker
        // false = ljus
        return false;
    }

    void UpdateSanity()
    {
        if (sanity > 75)
        {
            sanityBar.sprite = sanity100;
            faceImage.sprite = face100;
        }
        else if (sanity > 50)
        {
            sanityBar.sprite = sanity75;
            faceImage.sprite = face75;
        }
        else if (sanity > 25)
        {
            sanityBar.sprite = sanity50;
            faceImage.sprite = face50;
        }
        else if (sanity > 0)
        {
            sanityBar.sprite = sanity25;
            faceImage.sprite = face25;
        }
        else
        {
            sanityBar.sprite = sanity0;
            faceImage.sprite = face0;

            Debug.Log("Player died!");
        }
    }
}

