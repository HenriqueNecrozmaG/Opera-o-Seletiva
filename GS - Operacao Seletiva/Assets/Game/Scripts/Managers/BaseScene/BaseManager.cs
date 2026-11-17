using UnityEngine;
using UnityEngine.SceneManagement;

public enum BaseState
{
    Playing,
    Paused
}

public class BaseManager : MonoBehaviour
{
    public static BaseManager Instance { get; private set; }
    public BaseState CurrentState { get; private set; }

    [SerializeField] private int[] machineUpgradeCost;
    [SerializeField] private int[] playerUpgradeCost;
    [SerializeField] private int[] weaponUpgradeCost;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        BaseFacade.Instance.StartBaseScene();
        BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
        UpdateMachinePlayerAndWeaponTextsOnStart();
        DisableUpgradeButtons();
        DisableProgressBars();
        BaseFacade.Instance.MusicPlay(0);
        CurrentState = BaseState.Playing;
    }

    void UpdateMachinePlayerAndWeaponTextsOnStart()
    {
        ///MÁQUINA de PLÁSTICO///
        if (Resources.plasticMachineLevel < 2)
        {
            BaseFacade.Instance.UpdateUIPlasticMachineText(Resources.plasticMachineLevel, machineUpgradeCost[0]);
        }
        else if (Resources.plasticMachineLevel >= 2)
        {
            BaseFacade.Instance.UpdateUIPlasticMachineText(Resources.plasticMachineLevel, machineUpgradeCost[1]);
        }

        ///MÁQUINA de PAPEL///
        if (Resources.paperMachineLevel < 2)
        {
            BaseFacade.Instance.UpdateUIPaperMachineText(Resources.paperMachineLevel, machineUpgradeCost[0]);
        }
        else if (Resources.paperMachineLevel >= 2)
        {
            BaseFacade.Instance.UpdateUIPaperMachineText(Resources.paperMachineLevel, machineUpgradeCost[1]);
        }

        ///MÁQUINA de VIDRO///
        if (Resources.glassMachineLevel < 2)
        {
            BaseFacade.Instance.UpdateUIGlassMachineText(Resources.glassMachineLevel, machineUpgradeCost[0]);
        }
        else if (Resources.glassMachineLevel >= 2)
        {
            BaseFacade.Instance.UpdateUIGlassMachineText(Resources.glassMachineLevel, machineUpgradeCost[1]);
        }

        ///MÁQUINA de METAL///
        if (Resources.metalMachineLevel < 2)
        {
            BaseFacade.Instance.UpdateUIMetalMachineText(Resources.metalMachineLevel, machineUpgradeCost[0]);
        }
        else if (Resources.metalMachineLevel >= 2)
        {
            BaseFacade.Instance.UpdateUIMetalMachineText(Resources.metalMachineLevel, machineUpgradeCost[1]);
        }


        ///PLAYER & ARMA COLETORA///
        if (Resources.playerLevel < 2)
        {
            BaseFacade.Instance.UpdateUIPlayerText(Resources.playerLevel, playerUpgradeCost[0]);
        }
        else if (Resources.playerLevel >= 2)
        {
            BaseFacade.Instance.UpdateUIPlayerText(Resources.playerLevel, playerUpgradeCost[1]);
        }

        if (Resources.weaponLevel < 2)
        {
            BaseFacade.Instance.UpdateUIWeaponText(Resources.weaponLevel, weaponUpgradeCost[0]);
        }
        else if (Resources.playerLevel >= 2)
        {
            BaseFacade.Instance.UpdateUIWeaponText(Resources.weaponLevel, weaponUpgradeCost[1]);
        }
    }

    void DisableUpgradeButtons()
    {
        if (Resources.plasticMachineLevel >= 3)
        {
            BaseFacade.Instance.DisableUIUpgradePlasticButton();
        }

        if (Resources.paperMachineLevel >= 3)
        {
            BaseFacade.Instance.DisableUIUpgradePaperButton();
        }

        if (Resources.glassMachineLevel >= 3)
        {
            BaseFacade.Instance.DisableUIUpgradeGlassButton();
        }

        if (Resources.metalMachineLevel >= 3)
        {
            BaseFacade.Instance.DisableUIUpgradeMetalButton();
        }

        if (Resources.playerLevel >= 3)
        {
            BaseFacade.Instance.DisableUIUpgradePlayerButton();
        }

        if (Resources.weaponLevel >= 3)
        {
            BaseFacade.Instance.DisableUIUpgradeWeaponButton();
        }
    }

    private void DisableProgressBars()
    {
        BaseFacade.Instance.DisableUISliderPlastic();
        BaseFacade.Instance.DisableUISliderPaper();
        BaseFacade.Instance.DisableUISliderGlass();
        BaseFacade.Instance.DisableUISliderMetal();
    }

    void Update()
    {
        Pause();
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BaseFacade.Instance.PlayAudioSoundEffect(0);

            if (CurrentState == BaseState.Playing)
            {
                BaseFacade.Instance.ShowUIPausePanel();
                CurrentState = BaseState.Paused;
                BaseFacade.Instance.MusicPause();
                Time.timeScale = 0f;
            }
            else if (CurrentState == BaseState.Paused)
            {
                BaseFacade.Instance.HideUIPausePanel();
                BaseFacade.Instance.HideUIOptionsPanel();
                CurrentState = BaseState.Playing;
                BaseFacade.Instance.MusicUnPause();
                Time.timeScale = 1f;
            }
        }
    }

    public void Unpause()
    {
        BaseFacade.Instance.PlayAudioSoundEffect(0);
        BaseFacade.Instance.HideUIPausePanel();
        BaseFacade.Instance.HideUIOptionsPanel();
        CurrentState = BaseState.Playing;
        BaseFacade.Instance.MusicUnPause();
        Time.timeScale = 1f;
    }

    public void Options()
    {
        BaseFacade.Instance.PlayAudioSoundEffect(0);
        BaseFacade.Instance.ShowUIOptionsPanel();
    }

    public void CloseOptions()
    {
        BaseFacade.Instance.PlayAudioSoundEffect(0);
        BaseFacade.Instance.HideUIOptionsPanel();
    }

    public void Return()
    {
        BaseFacade.Instance.PlayAudioSoundEffect(0);
        Time.timeScale = 0f;
        SceneManager.LoadScene("StartScene");
    }

    public void UpgradePlasticMachine()
    {
        if (Resources.plasticMachineLevel == 1)
        {
            if (Resources.money >= machineUpgradeCost[0])
            {
                Resources.money -= machineUpgradeCost[0];
                Resources.plasticMachineLevel = 2;
                BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
                BaseFacade.Instance.UpdateUIPlasticMachineText(Resources.plasticMachineLevel, machineUpgradeCost[1]);
                BaseFacade.Instance.SpawnerUpgradePlasticMachine();
                return;
            }
            else
            {
                BaseFacade.Instance.ShowUIMoneyMessagePanel();
                return;
            }
        }

        if (Resources.plasticMachineLevel == 2)
        {
            if (Resources.money >= machineUpgradeCost[1])
            {
                Resources.money -= machineUpgradeCost[1];
                Resources.plasticMachineLevel = 3;
                BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
                BaseFacade.Instance.UpdateUIPlasticMachineText(Resources.plasticMachineLevel, machineUpgradeCost[1]);
                BaseFacade.Instance.SpawnerUpgradePlasticMachine();
                BaseFacade.Instance.DisableUIUpgradePlasticButton();
                return;
            }
            else
            {
                BaseFacade.Instance.ShowUIMoneyMessagePanel();
                return;
            }
        }
    }

    public void UpgradePaperMachine()
    {
        if (Resources.paperMachineLevel == 1)
        {
            if (Resources.money >= machineUpgradeCost[0])
            {
                Resources.money -= machineUpgradeCost[0];
                Resources.paperMachineLevel = 2;
                BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
                BaseFacade.Instance.UpdateUIPaperMachineText(Resources.paperMachineLevel, machineUpgradeCost[1]);
                BaseFacade.Instance.SpawnerUpgradePaperMachine();
                return;
            }
            else
            {
                BaseFacade.Instance.ShowUIMoneyMessagePanel();
                return;
            }
        }

        if (Resources.paperMachineLevel == 2)
        {
            if (Resources.money >= machineUpgradeCost[1])
            {
                Resources.money -= machineUpgradeCost[1];
                Resources.paperMachineLevel = 3;
                BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
                BaseFacade.Instance.UpdateUIPaperMachineText(Resources.paperMachineLevel, machineUpgradeCost[1]);
                BaseFacade.Instance.SpawnerUpgradePaperMachine();
                BaseFacade.Instance.DisableUIUpgradePaperButton();
                return;
            }
            else
            {
                BaseFacade.Instance.ShowUIMoneyMessagePanel();
                return;
            }
        }
    }

    public void UpgradeGlassMachine()
    {
        if (Resources.glassMachineLevel == 1)
        {
            if (Resources.money >= machineUpgradeCost[0])
            {
                Resources.money -= machineUpgradeCost[0];
                Resources.glassMachineLevel = 2;
                BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
                BaseFacade.Instance.UpdateUIGlassMachineText(Resources.glassMachineLevel, machineUpgradeCost[1]);
                BaseFacade.Instance.SpawnerUpgradeGlassMachine();
                return;
            }
            else
            {
                BaseFacade.Instance.ShowUIMoneyMessagePanel();
                return;
            }
        }

        if (Resources.glassMachineLevel == 2)
        {
            if (Resources.money >= machineUpgradeCost[1])
            {
                Resources.money -= machineUpgradeCost[1];
                Resources.glassMachineLevel = 3;
                BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
                BaseFacade.Instance.UpdateUIGlassMachineText(Resources.glassMachineLevel, machineUpgradeCost[1]);
                BaseFacade.Instance.SpawnerUpgradeGlassMachine();
                BaseFacade.Instance.DisableUIUpgradeGlassButton();
                return;
            }
            else
            {
                BaseFacade.Instance.ShowUIMoneyMessagePanel();
                return;
            }
        }
    }

    public void UpgradeMetalMachine()
    {
        if (Resources.metalMachineLevel == 1)
        {
            if (Resources.money >= machineUpgradeCost[0])
            {
                Resources.money -= machineUpgradeCost[0];
                Resources.metalMachineLevel = 2;
                BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
                BaseFacade.Instance.UpdateUIMetalMachineText(Resources.metalMachineLevel, machineUpgradeCost[1]);
                BaseFacade.Instance.SpawnerUpgradeMetalMachine();
                return;
            }
            else
            {
                BaseFacade.Instance.ShowUIMoneyMessagePanel();
                return;
            }
        }

        if (Resources.metalMachineLevel == 2)
        {
            if (Resources.money >= machineUpgradeCost[1])
            {
                Resources.money -= machineUpgradeCost[1];
                Resources.metalMachineLevel = 3;
                BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
                BaseFacade.Instance.UpdateUIMetalMachineText(Resources.metalMachineLevel, machineUpgradeCost[1]);
                BaseFacade.Instance.SpawnerUpgradeMetalMachine();
                BaseFacade.Instance.DisableUIUpgradeMetalButton();
                return;
            }
            else
            {
                BaseFacade.Instance.ShowUIMoneyMessagePanel();
                return;
            }
        }
    }

    public void UpgradePlayer()
    {
        if (Resources.playerLevel == 1)
        {
            if (Resources.money >= playerUpgradeCost[0])
            {
                Resources.money -= playerUpgradeCost[0];
                Resources.playerLevel = 2;
                BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
                BaseFacade.Instance.UpdateUIPlayerText(Resources.playerLevel, playerUpgradeCost[1]);
                return;
            }
            else
            {
                BaseFacade.Instance.ShowUIMoneyMessagePanel();
                return;
            }
        }

        if (Resources.playerLevel == 2)
        {
            if (Resources.money >= playerUpgradeCost[1])
            {
                Resources.money -= playerUpgradeCost[1];
                Resources.playerLevel = 3;
                BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
                BaseFacade.Instance.UpdateUIPlayerText(Resources.playerLevel, playerUpgradeCost[1]);
                BaseFacade.Instance.DisableUIUpgradePlayerButton();
                return;
            }
            else
            {
                BaseFacade.Instance.ShowUIMoneyMessagePanel();
                return;
            }
        }
    }

    public void UpgradeWeapon()
    {
        if (Resources.weaponLevel == 1)
        {
            if (Resources.money >= weaponUpgradeCost[0])
            {
                Resources.money -= weaponUpgradeCost[0];
                Resources.weaponLevel = 2;
                BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
                BaseFacade.Instance.UpdateUIWeaponText(Resources.weaponLevel, weaponUpgradeCost[1]);
                BaseFacade.Instance.SpawnerUpgradeWeapon();
                return;
            }
            else
            {
                BaseFacade.Instance.ShowUIMoneyMessagePanel();
                return;
            }
        }

        if (Resources.weaponLevel == 2)
        {
            if (Resources.money >= weaponUpgradeCost[1])
            {
                Resources.money -= weaponUpgradeCost[1];
                Resources.weaponLevel = 3;
                BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
                BaseFacade.Instance.UpdateUIWeaponText(Resources.weaponLevel, weaponUpgradeCost[1]);
                BaseFacade.Instance.SpawnerUpgradeWeapon();
                BaseFacade.Instance.DisableUIUpgradeWeaponButton();
                return;
            }
            else
            {
                BaseFacade.Instance.ShowUIMoneyMessagePanel();
                return;
            }
        }
    }
}