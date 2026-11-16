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

    public void PlayAudioSoundEffect(int i)
    {
        audioManager.PlaySoundEffect(i);
    }

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
