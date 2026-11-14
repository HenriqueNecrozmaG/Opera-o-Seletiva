using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public GameObject punchEffect;

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
        GameObject damageEffect = Instantiate(punchEffect);
        damageEffect.transform.position = new Vector3(0f, 1.2f, -5f);
        Destroy(damageEffect, 0.5f);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameManager.Instance.Defeat();
            gameObject.SetActive(false);
        }
    }
}
