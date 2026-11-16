using TMPro;
using UnityEngine;

public class UIManagerBase : MonoBehaviour
{
    [Header("Panel Settings")]
    [SerializeField] private GameObject panelHUD;
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelOptions;
    [SerializeField] private GameObject panelPlastic;
    [SerializeField] private GameObject panelPaper;
    [SerializeField] private GameObject panelGlass;
    [SerializeField] private GameObject panelMetal;
    [SerializeField] private GameObject panelWeapon;

    [Header("HUD Settings")]
    [SerializeField] private TextMeshProUGUI textPlastic;
    [SerializeField] private TextMeshProUGUI textPaper;
    [SerializeField] private TextMeshProUGUI textGlass;
    [SerializeField] private TextMeshProUGUI textMetal;
    [SerializeField] private TextMeshProUGUI textMoney;

    public void ShowHUD()
    {
        panelHUD.SetActive(true);
        panelPause.SetActive(false);
        panelOptions.SetActive(false);
        panelPlastic.SetActive(true);
        panelPaper.SetActive(false);
        panelGlass.SetActive(false);
        panelMetal.SetActive(false);
        panelWeapon.SetActive(false);
    }

    public void ShowPlasticPanel()
    {
        panelPlastic.SetActive(true);
        panelPaper.SetActive(false);
    }

    public void ShowPaperPanel()
    {
        panelPlastic.SetActive(false);
        panelPaper.SetActive(true);
        panelGlass.SetActive(false);
    }

    public void ShowGlassPanel()
    {
        panelPaper.SetActive(false);
        panelGlass.SetActive(true);
        panelMetal.SetActive(false);
    }

    public void ShowMetalPanel()
    {
        panelGlass.SetActive(false);
        panelMetal.SetActive(true);
        panelWeapon.SetActive(false);
    }

    public void ShowWeaponPanel()
    {
        panelMetal.SetActive(false);
        panelWeapon.SetActive(true);
    }

    public void UpdateResourcesText(int plasticQuantity, int paperQuantity, int glassQuantity, int metalQuantity, int moneyQuantity)
    {
        textPlastic.text = "Plástico: " + plasticQuantity;
        textPaper.text = "Papel: " + paperQuantity;
        textGlass.text = "Vidro: " + glassQuantity;
        textMetal.text = "Metal: " + metalQuantity;
        textMoney.text = "Dinheiro: " + moneyQuantity;
    }

    public void ShowPausePanel()
    {
        panelPause.SetActive(true);
    }

    public void HidePausePanel()
    {
        panelPause.SetActive(false);
    }

    public void ShowOptionsPanel()
    {
        panelOptions.SetActive(true);
    }

    public void HideOptionsPanel()
    {
        panelOptions.SetActive(false);
    }
}
