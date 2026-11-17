using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float[] maxHealth;
    public GameObject punchEffect;

    public float currentHealth;

    void Start()
    {
        if (Resources.playerLevel == 1)
        {
            currentHealth = maxHealth[0];
        }
        else if (Resources.playerLevel == 2)
        {
            currentHealth = maxHealth[1];
        }
        else if (Resources.playerLevel == 3)
        {
            currentHealth = maxHealth[2];
        }

        GameFacade.Instance.UpdateUIHealthBar(currentHealth, maxHealth[0]);
    }

    public void TakeDamage()
    {
        currentHealth--;
        GameFacade.Instance.PlayAudioSoundEffect(6);
        GameFacade.Instance.UpdateUIHealthBar(currentHealth, maxHealth[0]);
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
