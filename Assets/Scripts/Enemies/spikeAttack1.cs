
using UnityEngine;

public class spikeAttack1 : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3 attackDirection;
    private Vector3 destination;
    private float checkTimer;
    private Vector3 ogPosition;
    private bool attack;



    private void OnEnable()
    {
        Stop();
    }

    private void Awake()
    {
        ogPosition = transform.position;
    }

    private void Update()
    {
        if (attack)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }

    private void CheckForPlayer()
    {
        CalculateDirections();



        Debug.DrawRay(transform.position, attackDirection, Color.white);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, attackDirection, range, playerLayer);

        if (hit.collider != null && !attack)
        {
            attack = true;
            destination = transform.right * range;
            checkTimer = 0;
        }



    }
    private void CalculateDirections()
    {


        attackDirection = transform.up * range;

    }
    private void Stop()
    {

        destination = transform.position;
        attack = false;
    }

    public void ResetTrap()
    {
        transform.position = ogPosition;
        Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }


}
