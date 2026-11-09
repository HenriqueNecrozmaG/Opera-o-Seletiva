using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panelHUD;
    [SerializeField] private TextMeshProUGUI textMaterial;
    [SerializeField] private Slider healthBar;

    public void ShowHUD()
    {
        panelHUD.SetActive(true);
    }

    public void UpdateMaterialText(string text, Color color)
    {
        textMaterial.text = text;
        textMaterial.color = color;
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        healthBar.value = currentHealth/maxHealth;
    }
}
