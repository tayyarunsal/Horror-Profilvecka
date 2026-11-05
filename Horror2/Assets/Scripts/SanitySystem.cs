using UnityEngine;
using UnityEngine.UI;

public class SanitySystem : MonoBehaviour
{
    public float sanity = 100f;

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

    public float SanityLossSpeed = 5f;

    public float SanityGainSpeed = 5f;

    private bool IsInLight = false;

    void Start()
    {
        UpdateSanity();
    }

    void Update()
    {
        if (IsInLight)
        {
            sanity += SanityGainSpeed * Time.deltaTime;
        }
        else
        {
            sanity -= SanityLossSpeed * Time.deltaTime;
        }

        sanity = Mathf.Clamp(sanity, 0f, 100f);

        UpdateSanity();

    }

    public void SetInLight(bool value)
    {
        IsInLight = value;
    }


    public void ChangeSanity(float amount)
    {
        sanity += amount;

        sanity = Mathf.Clamp(sanity, 0f, 100f);

        UpdateSanity();
;    }


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