using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panel Settings")]
    [SerializeField] private GameObject panelHUD;
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelVictory;
    [SerializeField] private GameObject panelDefeat;
    [SerializeField] private GameObject panelDifficulty;

    [Header("HUD Settings")]
    [SerializeField] private TextMeshProUGUI textMaterial;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI textTime;
    [SerializeField] private TextMeshProUGUI textPlastic;
    [SerializeField] private TextMeshProUGUI textPaper;
    [SerializeField] private TextMeshProUGUI textGlass;
    [SerializeField] private TextMeshProUGUI textMetal;

    [Header("Victory Settings")]
    [SerializeField] private TextMeshProUGUI textPlasticVictory;
    [SerializeField] private TextMeshProUGUI textPaperVictory;
    [SerializeField] private TextMeshProUGUI textGlassVictory;
    [SerializeField] private TextMeshProUGUI textMetalVictory;

    [Header("Difficulty Settings")]
    [SerializeField] private TextMeshProUGUI textEasyTime;
    [SerializeField] private TextMeshProUGUI textMediumTime;
    [SerializeField] private TextMeshProUGUI textHardTime;
    
    public void ShowDifficultyPanel(float easyTime, float mediumTime, float hardTime)
    {
        panelDifficulty.SetActive(true);
        panelHUD.SetActive(false);
        panelPause.SetActive(false);
        panelVictory.SetActive(false);
        panelDefeat.SetActive(false);

        textEasyTime.text = "Tempo: " + easyTime;
        textMediumTime.text = "Tempo: " + mediumTime;
        textHardTime.text = "Tempo: " + hardTime;
    }

    public void ShowHUD()
    {
        panelHUD.SetActive(true);
        panelDifficulty.SetActive(false);
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

    public void UpdateMaterialQuantityVictoryTexts(int plasticQuantity, int paperQuantity, int glassQuantity, int metalQuantity)
    {
        textPlasticVictory.text = "Plástico: " + plasticQuantity;
        textPaperVictory.text = "Papel: " + paperQuantity;
        textGlassVictory.text = "Vidro: " + glassQuantity;
        textMetalVictory.text = "Metal: " + metalQuantity;
    }

    public void UpdateTextTime(int time)
    {
        textTime.text = time.ToString();
    }

    public void ShowPausePanel()
    {
        panelPause.SetActive(true);
    }

    public void HidePausePanel()
    {
        panelPause.SetActive(false);
    }

    public void ShowVictoryPanel()
    {
        panelVictory.SetActive(true);
        panelHUD.SetActive(false);
    }
    
    public void ShowDefeatPanel()
    {
        panelDefeat.SetActive(true);
        panelHUD.SetActive(false);
    }
}
