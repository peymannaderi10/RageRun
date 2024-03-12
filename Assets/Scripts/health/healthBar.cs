
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] private health alexHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;


    private void Start()
    {
        totalHealthBar.fillAmount = alexHealth.currentHealth / 10;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = alexHealth.currentHealth / 10;
    }
}
