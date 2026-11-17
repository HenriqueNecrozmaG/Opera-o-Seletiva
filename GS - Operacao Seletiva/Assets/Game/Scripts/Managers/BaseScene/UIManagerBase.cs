using TMPro;
using Unity.VisualScripting;
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
    [SerializeField] private GameObject panelMessageMoney;
    [SerializeField] private GameObject panelMessageMaterial;

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
    [SerializeField] private Slider sliderPlastic;

    [Header("Paper Settings")]
    [SerializeField] private TextMeshProUGUI textPaperMachineLevel;
    [SerializeField] private TextMeshProUGUI textPaperMachineUpgradeCost;
    [SerializeField] private Button buttonRecyclePaper;
    [SerializeField] private Button buttonUpgradePaper;
    [SerializeField] private Slider sliderPaper;

    [Header("Glass Settings")]
    [SerializeField] private TextMeshProUGUI textGlassMachineLevel;
    [SerializeField] private TextMeshProUGUI textGlassMachineUpgradeCost;
    [SerializeField] private Button buttonRecycleGlass;
    [SerializeField] private Button buttonUpgradeGlass;
    [SerializeField] private Slider sliderGlass;

    [Header("Metal Settings")]
    [SerializeField] private TextMeshProUGUI textMetalMachineLevel;
    [SerializeField] private TextMeshProUGUI textMetalMachineUpgradeCost;
    [SerializeField] private Button buttonRecycleMetal;
    [SerializeField] private Button buttonUpgradeMetal;
    [SerializeField] private Slider sliderMetal;

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
        panelMessageMoney.SetActive(false);
        panelMessageMaterial.SetActive(false);
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

    public void ShowMoneyMessagePanel()
    {
        panelMessageMoney.SetActive(true);
    }

    public void HideMoneyMessagePanel()
    {
        panelMessageMoney.SetActive(false);
    }

    public void ShowMaterialMessagePanel()
    {
        panelMessageMaterial.SetActive(true);
    }

    public void HideMaterialMessagePanel()
    {
        panelMessageMaterial.SetActive(false);
    }

    ///MÁQUINA DE PLÁSTICO///
    public void UpdatePlasticMachineText(int machineLevel, int cost)
    {
        textPlasticMachineLevel.text = "Máquina de Reciclagem de Plástico\nLvl " + machineLevel;

        if (machineLevel < 3)
        {
            textPlasticMachineUpgradeCost.text = "Melhorar: " + cost;
        }
        else
        {
            textPlasticMachineUpgradeCost.text = "Melhorado completamente";
        }
    }

    public void EnableRecyclePlasticButton()
    {
        buttonRecyclePlastic.interactable = true;
    }
    
    public void DisableRecyclePlasticButton()
    {
        buttonRecyclePlastic.interactable = false;
    }

    public void EnableUpgradePlasticButton()
    {
        buttonUpgradePlastic.interactable = true;
    }

    public void DisableUpgradePlasticButton()
    {
        buttonUpgradePlastic.interactable = false;
    }

    public void EnableSliderPlastic()
    {
        sliderPlastic.gameObject.SetActive(true);
    }
    
    public void DisableSliderPlastic()
    {
        sliderPlastic.gameObject.SetActive(false);
    }

    public void UpdateSliderPlastic(float value)
    {
        sliderPlastic.value = value;
    }

    ///MÁQUINA DE PAPEL///
    public void UpdatePaperMachineText(int machineLevel, int cost)
    {
        textPaperMachineLevel.text = "Máquina de Reciclagem de Papel\nLvl " + machineLevel;

        if (machineLevel < 3)
        {
            textPaperMachineUpgradeCost.text = "Melhorar: " + cost;
        }
        else
        {
            textPaperMachineUpgradeCost.text = "Melhorado completamente";
        }
    }

    public void EnableRecyclePaperButton()
    {
        buttonRecyclePaper.interactable = true;
    }

    public void DisableRecyclePaperButton()
    {
        buttonRecyclePaper.interactable = false;
    }

    public void EnableUpgradePaperButton()
    {
        buttonUpgradePaper.interactable = true;
    }

    public void DisableUpgradePaperButton()
    {
        buttonUpgradePaper.interactable = false;
    }

    public void EnableSliderPaper()
    {
        sliderPaper.gameObject.SetActive(true);
    }

    public void DisableSliderPaper()
    {
        sliderPaper.gameObject.SetActive(false);
    }

    public void UpdateSliderPaper(float value)
    {
        sliderPaper.value = value;
    }

    ///MÁQUINA DE VIDRO///
    public void UpdateGlassMachineText(int machineLevel, int cost)
    {
        textGlassMachineLevel.text = "Máquina de Reciclagem de Vidro\nLvl " + machineLevel;

        if (machineLevel < 3)
        {
            textGlassMachineUpgradeCost.text = "Melhorar: " + cost;
        }
        else
        {
            textGlassMachineUpgradeCost.text = "Melhorado completamente";
        }
    }

    public void EnableRecycleGlassButton()
    {
        buttonRecycleGlass.interactable = true;
    }

    public void DisableRecycleGlassButton()
    {
        buttonRecycleGlass.interactable = false;
    }

    public void EnableUpgradeGlassButton()
    {
        buttonUpgradeGlass.interactable = true;
    }

    public void DisableUpgradeGlassButton()
    {
        buttonUpgradeGlass.interactable = false;
    }

    public void EnableSliderGlass()
    {
        sliderGlass.gameObject.SetActive(true);
    }

    public void DisableSliderGlass()
    {
        sliderGlass.gameObject.SetActive(false);
    }

    public void UpdateSliderGlass(float value)
    {
        sliderGlass.value = value;
    }

    ///MÁQUINA DE METAL///
    public void UpdateMetalMachineText(int machineLevel, int cost)
    {
        textMetalMachineLevel.text = "Máquina de Reciclagem de Metal\nLvl " + machineLevel;

        if (machineLevel < 3)
        {
            textMetalMachineUpgradeCost.text = "Melhorar: " + cost;
        }
        else
        {
            textMetalMachineUpgradeCost.text = "Melhorado completamente";
        }
    }

    public void EnableRecycleMetalButton()
    {
        buttonRecycleMetal.interactable = true;
    }

    public void DisableRecycleMetalButton()
    {
        buttonRecycleMetal.interactable = false;
    }

    public void EnableUpgradeMetalButton()
    {
        buttonUpgradeMetal.interactable = true;
    }

    public void DisableUpgradeMetalButton()
    {
        buttonUpgradeMetal.interactable = false;
    }

    public void EnableSliderMetal()
    {
        sliderMetal.gameObject.SetActive(true);
    }

    public void DisableSliderMetal()
    {
        sliderMetal.gameObject.SetActive(false);
    }

    public void UpdateSliderMetal(float value)
    {
        sliderMetal.value = value;
    }

    ///PLAYER & ARMA///
    public void UpdatePlayerText(int playerLevel, int playerCost)
    {
        textPlayerLevel.text = "Jogador - Lvl " + playerLevel;;

        if (playerLevel < 3)
        {
            textPlayerUpgradeCost.text = "Melhorar Jogador: " + playerCost;
        }
        else
        {
            textPlayerUpgradeCost.text = "Melhorado completamente";
        }
    }

    public void UpdateWeaponText(int weaponLevel, int weaponCost)
    {
        textWeaponLevel.text = "Arma Coletora - Lvl " + weaponLevel;

        if (weaponLevel < 3)
        {
            textWeaponUpgradeCost.text = "Melhorar Arma: " + weaponCost;
        }
        else
        {
            textWeaponUpgradeCost.text = "Melhorado completamente";
        }
    }

    public void EnableUpgradePlayerButton()
    {
        buttonUpgradePlayer.interactable = true;
    }

    public void DisableUpgradePlayerButton()
    {
        buttonUpgradePlayer.interactable = false;
    }
    
    public void EnableUpgradeWeaponButton()
    {
        buttonUpgradeWeapon.interactable = true;
    }

    public void DisableUpgradeWeaponButton()
    {
        buttonUpgradeWeapon.interactable = false;
    }
}