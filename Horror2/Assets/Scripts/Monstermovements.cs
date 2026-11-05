using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonsterMovement : MonoBehaviour
{
    [Header("Player")]
    public Transform player;

    [Header("Monster Image")]
    public Image monsterImage;
    public Sprite[] monsterSprites;

    [Header("Movement")]
    public float moveSpeed = 2f;
    public float animationSpeed = 0.2f;

    [Header("Sanity")]
    public SanitySystem sanitySystem;
    public float sanityLossPerSecond = 5f;

    [Header("Blinking")]
    public KeyCode blinkKey = KeyCode.Space;

    [Header("Black Screen")]
    public Image blackScreen;
    public float blackScreenTime = 1f;

    private int currentFrame = 0;
    private float animationTimer = 0f;

    private bool monsterActive = false;
    private bool eventFinished = false;

    void Start()
    {
        monsterImage.sprite = monsterSprites[0];

        // Monstret börjar stilla
        monsterActive = false;

        // Black screen ska vara osynlig
        if (blackScreen != null)
        {
            blackScreen.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Starta monster-eventet när monstret är aktivt
        if (monsterActive && !eventFinished)
        {
            // Om spelaren blundar
            if (Input.GetKey(blinkKey))
            {
                MonsterGoesAway();
                return;
            }

            // Spelaren tittar fortfarande
            MoveTowardsPlayer();
            AnimateMonster();

            // Sanity minskar medan monstret syns
            if (sanitySystem != null)
            {
                sanitySystem.LoseSanity(
                    Mathf.RoundToInt(sanityLossPerSecond * Time.deltaTime)
                );
            }

            // Om monstret kommer nära spelaren
            float distance = Vector3.Distance(
                transform.position,
                player.position
            );

            if (distance < 1f)
            {
                StartCoroutine(MonsterAttack());
            }
        }
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            moveSpeed * Time.deltaTime
        );
    }

    void AnimateMonster()
    {
        animationTimer += Time.deltaTime;

        if (animationTimer >= animationSpeed)
        {
            animationTimer = 0f;

            currentFrame++;

            if (currentFrame >= monsterSprites.Length)
            {
                currentFrame = 0;
            }

            monsterImage.sprite = monsterSprites[currentFrame];
        }
    }

    void MonsterGoesAway()
    {
        monsterActive = false;

        // Monstret försvinner
        gameObject.SetActive(false);

        Debug.Log("Player blinked! Monster went away.");
    }

    IEnumerator MonsterAttack()
    {
        eventFinished = true;

        // Black screen
        if (blackScreen != null)
        {
            blackScreen.gameObject.SetActive(true);
        }

        // Vänta 1 sekund
        yield return new WaitForSeconds(blackScreenTime);

        // Ta bort 50 sanity
        if (sanitySystem != null)
        {
            sanitySystem.LoseSanity(50);
        }

        // Ta bort black screen
        if (blackScreen != null)
        {
            blackScreen.gameObject.SetActive(false);
        }

        // Monstret försvinner
        gameObject.SetActive(false);
    }

    // Använd denna för att starta monster-eventet
    public void StartMonster()
    {
        monsterActive = true;
        eventFinished = false;

        currentFrame = 0;
        monsterImage.sprite = monsterSprites[0];

        gameObject.SetActive(true);
    }
}



