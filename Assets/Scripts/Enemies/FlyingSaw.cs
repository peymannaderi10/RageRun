
using UnityEngine;

public class FlyingSaw : EnemyDamage
{
    
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private bool goRight;
    private Vector3[] directions = new Vector3[2];
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
            transform.Translate(destination*Time.deltaTime*speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }

    private void CheckForPlayer() { 
        CalculateDirections();

        for (int i = 0; i < directions.Length; i++) { 
        
            Debug.DrawRay(transform.position, directions[i], Color.white);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if(hit.collider != null && !attack)
            {
                attack = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    
    
    }
    private void CalculateDirections() {

        if (goRight)
        {
            directions[0] = transform.right * range; // right
            directions[1] = -transform.right * range*0.90f; // left

        }
        else
        {
            directions[0] = -transform.right * range; // left
        }


    }
    private void Stop() { 
    
        destination = transform.position;
        attack = false;
    }

    public void ResetSaw()
    {
        transform.position = ogPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Stop();
    }



}


