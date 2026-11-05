using UnityEngine;

public class MonsterWorm : MonoBehaviour
{
    public float crawlSpeed = 2f;
    public float lungeSpeed = 15f;
    public float launchDistance = 4f;
    public float biteDistance = 1f;
    public float sanityDamage = 50f;

    private Transform player;
    private SanitySystem sanitySystem;

    private bool isLunging = false;
    private bool hasBitten = false;

    void Start()
    {

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
            sanitySystem = playerObj.GetComponent<SanitySystem>();

            if (sanitySystem == null)
            {
                sanitySystem = FindFirstObjectByType<SanitySystem>();
            }
        }
    }

    void Update()
    {

        if (player == null || hasBitten) return;


        float distanceToPlayer = Vector2.Distance(transform.position, player.position);


        if (!isLunging)
        {
            MoveTowardsPlayer(crawlSpeed);

            if (distanceToPlayer <= launchDistance)
            {
                isLunging = true;
            }
        }
        else
        {
            MoveTowardsPlayer(lungeSpeed);

            if (distanceToPlayer <= biteDistance)
            {
                BitePlayer();
            }
        }
    }


    private void MoveTowardsPlayer(float speed)
    {

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);


        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void BitePlayer()
    {
        hasBitten = true;
        if (sanitySystem != null)
        {
            sanitySystem.ChangeSanity(-sanityDamage);
            Debug.Log("Worm bit the player -50 Sanity.");
        }
    }
}