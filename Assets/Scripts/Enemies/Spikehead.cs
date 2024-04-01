using UnityEngine;

public class Spikehead : EnemyDamage
{

    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private float checkTimer;
    private Vector3 destination;
    private Vector3[] directions = new Vector3[4];
    private bool attacking;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    private void onEnable(){
        Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if(checkTimer > checkDelay)
                checkForPlayer();
        }
        
    }

    private void checkForPlayer()
    {
        calculateDirections();
        for(int i=0; i < directions.Length; i++){
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if(hit.collider != null && !attacking){
                attacking = true;
                destination = directions[i];
                checkTimer = 0;

            }
        }
    }
    private void calculateDirections()
    {
        directions[0] = transform.right * range;
        directions[1] = -transform.right * range;
        directions[2] = transform.up * range;
        directions[3] = -transform.up * range;
    }

    private void Stop(){
        destination = transform.position;
        attacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collison){
        base.OnTriggerEnter2D(collison);
        Stop();
    }
}
