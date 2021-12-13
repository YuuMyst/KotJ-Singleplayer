using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //SerializeField - see PlayerMovement
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if a player collects it
        if (collision.tag == "Player") 
        {
            collision.GetComponent<Health>().AddHealth(healthValue); //Increases current health
            gameObject.SetActive(false); //Disables object
        }
    }

}
