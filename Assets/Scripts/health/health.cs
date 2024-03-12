
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set;}
    private Animator anim;
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    [SerializeField] private AudioClip deathSound;


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Initialize the Rigidbody2D reference

    }



    public void TakeDamage(float _damage) {

        currentHealth = Mathf.Clamp(currentHealth - 1, 0, startingHealth);
        SoundManager.instance.PlaySound(deathSound);
        anim.SetBool("grounded", true);
        anim.SetTrigger("die");
        GetComponent<AlexMovements>().enabled = false;

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f; // Also clear any rotational velocity
        }

    }

    public void Respawn()
    {
        if (currentHealth > 0) {
            anim.ResetTrigger("die");
            anim.Play("Idle");
            GetComponent<AlexMovements>().enabled = true;

        }
    }


}
