using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Plastic Settings")]
    [SerializeField] private TextMeshProUGUI textPlasticMachineLevel;
    [SerializeField] private TextMeshProUGUI textPlasticMachineUpgradeCost;
    [SerializeField] private Button buttonRecyclePlastic;
    [SerializeField] private Button buttonUpgradePlastic;

    [Header("Paper Settings")]
    [SerializeField] private TextMeshProUGUI textPaperMachineLevel;
    [SerializeField] private TextMeshProUGUI textPaperMachineUpgradeCost;
    [SerializeField] private Button buttonRecyclePaper;
    [SerializeField] private Button buttonUpgradePaper;

    [Header("Glass Settings")]
    [SerializeField] private TextMeshProUGUI textGlassMachineLevel;
    [SerializeField] private TextMeshProUGUI textGlassMachineUpgradeCost;
    [SerializeField] private Button buttonRecycleGlass;
    [SerializeField] private Button buttonUpgradeGlass;

    [Header("Metal Settings")]
    [SerializeField] private TextMeshProUGUI textMetalMachineLevel;
    [SerializeField] private TextMeshProUGUI textMetalMachineUpgradeCost;
    [SerializeField] private Button buttonRecycleMetal;
    [SerializeField] private Button buttonUpgradeMetal;

    [Header("Player & Weapon Settings")]
    [SerializeField] private TextMeshProUGUI textPlayerLevel;
    [SerializeField] private TextMeshProUGUI textPlayerUpgradeCost;
    [SerializeField] private TextMeshProUGUI textWeaponLevel;
    [SerializeField] private TextMeshProUGUI textWeaponUpgradeCost;
    [SerializeField] private Button buttonUpgradePlayer;
    [SerializeField] private Button buttonUpgradeWeapon;

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

    ///MÁQUINA DE PLÁSTICO///
    public void UpdatePlasticMachineText(int machineLevel, int cost)
    {
        textPlasticMachineLevel.text = "Máquina de Reciclagem de Plástico\nLvl " + machineLevel;
        textPlasticMachineUpgradeCost.text = "Melhorar: " + cost;
    }

    public void EnableRecyclePlasticButton()
    {
        buttonRecyclePlastic.enabled = true;
    }
    
    public void DisableRecyclePlasticButton()
    {
        buttonRecyclePlastic.enabled = false;
    }

    public void EnableUpgradePlasticButton()
    {
        buttonUpgradePlastic.enabled = true;
    }

    public void DisableUpgradePlasticButton()
    {
        buttonUpgradePlastic.enabled = false;
    }

    ///MÁQUINA DE PAPEL///
    public void UpdatePaperMachineText(int machineLevel, int cost)
    {
        textPaperMachineLevel.text = "Máquina de Reciclagem de Papel\nLvl " + machineLevel;
        textPaperMachineUpgradeCost.text = "Melhorar: " + cost;
    }

    public void EnableRecyclePaperButton()
    {
        buttonRecyclePaper.enabled = true;
    }

    public void DisableRecyclePaperButton()
    {
        buttonRecyclePaper.enabled = false;
    }

    public void EnableUpgradePaperButton()
    {
        buttonUpgradePaper.enabled = true;
    }

    public void DisableUpgradePaperButton()
    {
        buttonUpgradePaper.enabled = false;
    }

    ///MÁQUINA DE VIDRO///
    public void UpdateGlassMachineText(int machineLevel, int cost)
    {
        textGlassMachineLevel.text = "Máquina de Reciclagem de Vidro\nLvl " + machineLevel;
        textGlassMachineUpgradeCost.text = "Melhorar: " + cost;
    }

    public void EnableRecycleGlassButton()
    {
        buttonRecycleGlass.enabled = true;
    }

    public void DisableRecycleGlassButton()
    {
        buttonRecycleGlass.enabled = false;
    }

    public void EnableUpgradeGlassButton()
    {
        buttonUpgradeGlass.enabled = true;
    }

    public void DisableUpgradeGlasscButton()
    {
        buttonUpgradeGlass.enabled = false;
    }

    ///MÁQUINA DE METAL///
    public void UpdateMetalMachineText(int metalMachineLevel, int cost)
    {
        textMetalMachineLevel.text = "Máquina de Reciclagem de Metal\nLvl " + metalMachineLevel;
        textMetalMachineUpgradeCost.text = "Melhorar: " + cost;
    }

    public void EnableRecycleMetalButton()
    {
        buttonRecycleMetal.enabled = true;
    }

    public void DisableRecycleMetalButton()
    {
        buttonRecycleMetal.enabled = false;
    }

    public void EnableUpgradeMetalButton()
    {
        buttonUpgradeMetal.enabled = true;
    }

    public void DisableUpgradeMetalButton()
    {
        buttonUpgradeMetal.enabled = false;
    }

    ///PLAYER & ARMA///
    public void UpdatePlayerGunText(int playerLevel, int playerCost, int weaponLevel, int weaponCost)
    {
        textPlayerLevel.text = "Jogador - Lvl " + playerLevel;
        textPlayerUpgradeCost.text = "Melhorar: " + playerCost;

        textPlayerLevel.text = "Arma Coletora - Lvl " + weaponLevel;
        textPlayerUpgradeCost.text = "Melhorar: " + weaponCost;
    }

    public void EnableUpgradePlayerButton()
    {
        buttonUpgradePlayer.enabled = true;
    }

    public void DisableUpgradePlayerButton()
    {
        buttonUpgradePlayer.enabled = false;
    }
    
    public void EnableUpgradeWeaponButton()
    {
        buttonUpgradeWeapon.enabled = true;
    }

    public void DisableUpgradeWeaponButton()
    {
        buttonUpgradeWeapon.enabled = false;
    }
}
