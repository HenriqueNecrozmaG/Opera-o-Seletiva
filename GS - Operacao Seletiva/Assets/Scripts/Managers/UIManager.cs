using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panelHUD;
    [SerializeField] private TextMeshProUGUI textMaterial;
    [SerializeField] private Slider healthBar;

    [SerializeField] private TextMeshProUGUI textPlastic;
    [SerializeField] private TextMeshProUGUI textPaper;
    [SerializeField] private TextMeshProUGUI textGlass;
    [SerializeField] private TextMeshProUGUI textMetal;

    [SerializeField] private TextMeshProUGUI textTime;

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

    public void UpdateMaterialQuantityTexts(int plasticQuantity, int paperQuantity, int glassQuantity, int metalQuantity)
    {
        textPlastic.text = "Plástico: " + plasticQuantity;
        textPaper.text = "Papel: " + paperQuantity;
        textGlass.text = "Vidro: " + glassQuantity;
        textMetal.text = "Metal: " + metalQuantity;
    }

    public void UpdateTextTime(int time)
    {
        textTime.text = time.ToString();
    }
}
