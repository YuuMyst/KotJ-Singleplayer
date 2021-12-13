using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //SerializeField - see PlayerMovement
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    //Calculates healthbar
    private void Start() {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    //Checks for Health changes & adjusts (+/-)
    private void Update() {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
