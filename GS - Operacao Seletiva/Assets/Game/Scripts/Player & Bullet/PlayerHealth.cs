using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
        GameFacade.Instance.UpdateUIHealthBar(currentHealth, maxHealth);
    }

    public void TakeDamage()
    {
        currentHealth--;
        GameFacade.Instance.PlayAudioSoundEffect(6);
        GameFacade.Instance.UpdateUIHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameManager.Instance.Defeat();
            gameObject.SetActive(false);
        }
    }
}
