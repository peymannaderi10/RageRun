using UnityEngine;

public class CeilingTrapDouble : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay; // Delay between checks for the player
    [SerializeField] private float resetDelay; // Delay to reset the detection after the first hit
    [SerializeField] private LayerMask playerLayer;
    private Vector3 attackDirection;
    private Vector3 destination;
    private Vector3 ogPosition;
    private bool attack;
    private bool firstDetection = false;
    private float firstDetectionTimer = 0f;

    private void OnEnable()
    {
        ResetTrap();
    }

    private void Awake()
    {
        ogPosition = transform.position;
    }

    private void Update()
    {
        if (attack)
        {
            transform.Translate(destination * Time.deltaTime * speed);
        }
        else
        {
            if (firstDetection)
            {
                firstDetectionTimer += Time.deltaTime;
                if (firstDetectionTimer >= resetDelay)
                {
                    // Ready for second detection
                    CheckForPlayer(true);
                }
            }
            else
            {
                CheckForPlayer(false);
            }
        }
    }

    private void CheckForPlayer(bool secondDetection)
    {
        Debug.DrawRay(transform.position, transform.up * range, Color.white);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, range, playerLayer);
        if (hit.collider != null)
        {
            if (!secondDetection)
            {
                // First detection
                firstDetection = true;
                firstDetectionTimer = 0; // Start timer for second detection
            }
            else
            {
                // Second detection
                Attack();
            }
        }
        else if (!secondDetection)
        {
            // No hit, reset first detection if it was in the waiting period for a second hit
            firstDetection = false;
            firstDetectionTimer = 0;
        }
    }

    private void Attack()
    {
        attack = true;
        destination = -transform.up * range;
        firstDetection = false;
        firstDetectionTimer = 0;
    }

    public void ResetTrap()
    {
        transform.position = ogPosition;
        attack = false;
        firstDetection = false;
        firstDetectionTimer = 0;
    }
}
