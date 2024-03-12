
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player") {
            collision.GetComponent<health>().TakeDamage(damage);
        }
    }
}
