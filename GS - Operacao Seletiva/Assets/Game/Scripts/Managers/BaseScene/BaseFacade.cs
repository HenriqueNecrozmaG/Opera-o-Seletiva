using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class BaseFacade : MonoBehaviour
{
    public static BaseFacade Instance { get; private set; }

    [SerializeField] private UIManagerBase uiManager;
    [SerializeField] private SpawnMachinesAndWeapon spawner;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private MusicManager musicManager;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
    }

    public void StartBaseScene()
    {
        uiManager.ShowHUD();
        spawner.SpawnPlasticMachine();
        spawner.SpawnPaperMachine();
        spawner.SpawnGlassMachine();
        spawner.SpawnMetalMachine();
        spawner.SpawnWeapon();
    }

    /*
    /// UI MANAGER
    */

    public void ShowUIPlasticPanel()
    {
        uiManager.ShowPlasticPanel();
    }

    public void ShowUIPaperPanel()
    {
        uiManager.ShowPaperPanel();
    }

    public void ShowUIGlassPanel()
    {
        uiManager.ShowGlassPanel();
    }

    public void ShowUIMetalPanel()
    {
        uiManager.ShowMetalPanel();
    }

    public void ShowUIWeaponPanel()
    {
        uiManager.ShowWeaponPanel();
    }

    public void UpdateUIResourcesText(int plasticQuantity, int paperQuantity, int glassQuantity, int metalQuantity, int moneyQuantity)
    {
        uiManager.UpdateResourcesText(plasticQuantity, paperQuantity, glassQuantity, metalQuantity, moneyQuantity);
    }

    public void ShowUIPausePanel()
    {
        uiManager.ShowPausePanel();
    }

    public void HideUIPausePanel()
    {
        uiManager.HidePausePanel();
    }

    public void ShowUIOptionsPanel()
    {
        uiManager.ShowOptionsPanel();
    }

    public void HideUIOptionsPanel()
    {
        uiManager.HideOptionsPanel();
    }

    public void ShowUIMoneyMessagePanel()
    {
        uiManager.ShowMoneyMessagePanel();
    }

    public void HideUIMoneyMessagePanel()
    {
        uiManager.HideMoneyMessagePanel();
    }

    public void ShowUIMaterialMessagePanel()
    {
        uiManager.ShowMaterialMessagePanel();
    }

    public void HideUIMaterialMessagePanel()
    {
        uiManager.HideMaterialMessagePanel();
    }

    ///UI da MÁQUINA de PLÁSTICO///
    public void UpdateUIPlasticMachineText(int machineLevel, int cost)
    {
        uiManager.UpdatePlasticMachineText(machineLevel, cost);
    }

    public void EnableUIRecyclePlasticButton()
    {
        uiManager.EnableRecyclePlasticButton();
    }

    public void DisableUIRecyclePlasticButton()
    {
        uiManager.DisableRecyclePlasticButton();
    }

    public void EnableUIUpgradePlasticButton()
    {
        uiManager.EnableUpgradePlasticButton();
    }

    public void DisableUIUpgradePlasticButton()
    {
        uiManager.DisableUpgradePlasticButton();
    }

    ///UI da MÁQUINA de PAPEL///
    public void UpdateUIPaperMachineText(int machineLevel, int cost)
    {
        uiManager.UpdatePaperMachineText(machineLevel, cost);
    }

    public void EnableUIRecyclePaperButton()
    {
        uiManager.EnableRecyclePaperButton();
    }

    public void DisableUIRecyclePaperButton()
    {
        uiManager.DisableRecyclePaperButton();
    }

    public void EnableUIUpgradePaperButton()
    {
        uiManager.EnableUpgradePaperButton();
    }

    public void DisableUIUpgradePaperButton()
    {
        uiManager.DisableUpgradePaperButton();
    }

    ///UI da MÁQUINA de VIDRO///
    public void UpdateUIGlassMachineText(int machineLevel, int cost)
    {
        uiManager.UpdateGlassMachineText(machineLevel, cost);
    }

    public void EnableUIRecycleGlassButton()
    {
        uiManager.EnableRecycleGlassButton();
    }

    public void DisableUIRecycleGlassButton()
    {
        uiManager.DisableRecycleGlassButton();
    }

    public void EnableUIUpgradeGlassButton()
    {
        uiManager.EnableUpgradeGlassButton();
    }

    public void DisableUIUpgradeGlassButton()
    {
        uiManager.DisableUpgradeGlassButton();
    }

    ///UI da MÁQUINA de METAL///
    public void UpdateUIMetalMachineText(int machineLevel, int cost)
    {
        uiManager.UpdateMetalMachineText(machineLevel, cost);
    }

    public void EnableUIRecycleMetalButton()
    {
        uiManager.EnableRecycleMetalButton();
    }

    public void DisableUIRecycleMetalButton()
    {
        uiManager.DisableRecycleMetalButton();
    }

    public void EnableUIUpgradeMetalButton()
    {
        uiManager.EnableUpgradeMetalButton();
    }

    public void DisableUIUpgradeMetalButton()
    {
        uiManager.DisableUpgradeMetalButton();
    }

    ///UI do PLAYER e da ARMA COLETORA///
    public void UpdateUIPlayerText(int playerLevel, int playerCost)
    {
        uiManager.UpdatePlayerText(playerLevel, playerCost);
    }

    public void UpdateUIWeaponText(int weaponLevel, int weaponCost)
    {
        uiManager.UpdateWeaponText(weaponLevel, weaponCost);
    }

    public void EnableUIUpgradePlayerButton()
    {
        uiManager.EnableUpgradePlayerButton();
    }

    public void DisableUIUpgradePlayerButton()
    {
        uiManager.DisableUpgradePlayerButton();
    }

    public void EnableUIUpgradeWeaponButton()
    {
        uiManager.EnableUpgradeWeaponButton();
    }

    public void DisableUIUpgradeWeaponButton()
    {
        uiManager.DisableUpgradeWeaponButton();
    }

    /*
    /// SPAWNER
    */

    public void SpawnerUpgradePlasticMachine()
    {
        spawner.UpgradePlasticMachine();
    }

    public void SpawnerUpgradePaperMachine()
    {
        spawner.UpgradePaperMachine();
    }

    public void SpawnerUpgradeGlassMachine()
    {
        spawner.UpgradeGlassMachine();
    }

    public void SpawnerUpgradeMetalMachine()
    {
        spawner.UpgradeMetalMachine();
    }

    public void SpawnerUpgradeWeapon()
    {
        spawner.UpgradeWeapon();
    }

    /*
    /// AUDIO MANAGER
    */

    public void PlayAudioSoundEffect(int i)
    {
        audioManager.PlaySoundEffect(i);
    }

    /*
    /// MUSIC MANAGER
    */

    public void MusicPlay(int i)
    {
        musicManager.Play(i);
    }

    public void MusicPause()
    {
        musicManager.Pause();
    }
    public void MusicUnPause()
    {
        musicManager.UnPause();
    }

    public void MusicStop()
    {
        musicManager.Stop();
    }
}