using UnityEngine;

public class alexRespawn3 : MonoBehaviour
{
    private health playerHealth;
    private Transform startRoom;
    private UIManager uiManager;
    [SerializeField] private AudioClip[] taunts;


    private void Awake()
    {
        playerHealth = GetComponent<health>();
        uiManager = FindObjectOfType<UIManager>();
    }


    public void Respawn() {

        int randomIndex = Random.Range(0, taunts.Length);

        // Play a random taunt from the array using the generated index
        // SoundManager.instance.PlaySound(taunts[randomIndex]);

        if (playerHealth.currentHealth > 0)
        {
            transform.position = startRoom.position;
            playerHealth.Respawn();
            Camera.main.GetComponent<CameraMovement>().MovetoStart(startRoom.parent);
            Key key = FindObjectOfType<Key>();
            if (key != null) key.ResetKey();
            CielingTrap cielingTrap = FindObjectOfType<CielingTrap>();
            cielingTrap.ResetTrap();
            CielingTrap1 cielingTrap1 = FindObjectOfType<CielingTrap1>();
            cielingTrap1.ResetTrap();
            CielingTrap2 cielingTrap2 = FindObjectOfType<CielingTrap2>();
            cielingTrap2.ResetTrap();
            CielingTrap3 cielingTrap3 = FindObjectOfType<CielingTrap3>();
            cielingTrap3.ResetTrap();
            SpikeAttack spike = FindObjectOfType<SpikeAttack>();
            spike.ResetTrap();
            FlyingSaw saw = FindObjectOfType<FlyingSaw>();
            saw.ResetSaw();
            FlyingSaw1 saw1 = FindObjectOfType<FlyingSaw1>();
            saw1.ResetSaw();
            Spikehead spikehead1 = FindObjectOfType<Spikehead>();
            spikehead1.ResetTrap();
        }
        else
        {
            uiManager.GameOver();
            return;

        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Start")
        {
            startRoom = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
