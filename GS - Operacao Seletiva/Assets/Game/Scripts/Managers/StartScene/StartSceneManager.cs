using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartSceneManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private GameObject panelOptions;
    [SerializeField] private GameObject panelControls;
    [SerializeField] private GameObject panelConfirm;

    void Awake()
    {
        LoadResources();
    }

    void Start()
    {
        Time.timeScale = 1f;
        musicManager.Play(0);
        panelOptions.SetActive(false);
        panelControls.SetActive(false);
        panelConfirm.SetActive(false);
    }

    public void Play()
    {
        audioManager.PlaySoundEffect(0);
        SceneManager.LoadScene("GameScene");
    }

    public void GoToBase()
    {
        audioManager.PlaySoundEffect(0);
        SceneManager.LoadScene("BaseScene");
    }

    public void Options()
    {
        audioManager.PlaySoundEffect(0);
        panelOptions.SetActive(true);
    }
    
    public void CloseOptions()
    {
        audioManager.PlaySoundEffect(0);
        panelOptions.SetActive(false);
    }

    public void Controls()
    {
        audioManager.PlaySoundEffect(0);
        panelControls.SetActive(true);
    }
    
    public void CloseControls()
    {
        audioManager.PlaySoundEffect(0);
        panelControls.SetActive(false);
    }

    public void SaveAndQuit()
    {
        SaveResources();
        audioManager.PlaySoundEffect(0);
        StartCoroutine(QuitCoroutine());
    }

    IEnumerator QuitCoroutine()
    {
        yield return new WaitForSeconds(1f);

        print("Saiu");
        Application.Quit();
    }

    public void ClearProgress()
    {
        audioManager.PlaySoundEffect(0);
        panelConfirm.SetActive(true);
    }

    public void ConfirmClear()
    {
        audioManager.PlaySoundEffect(0);
        ClearResources();
        panelConfirm.SetActive(false);
    }

    public void DeclineClear()
    {
        audioManager.PlaySoundEffect(0);
        panelConfirm.SetActive(false);
    }

    public void SaveResources()
    {
        PlayerPrefs.SetInt("Plastic", Resources.plastic);
        PlayerPrefs.SetInt("Paper", Resources.paper);
        PlayerPrefs.SetInt("Glass", Resources.glass);
        PlayerPrefs.SetInt("Metal", Resources.metal);
        PlayerPrefs.SetInt("Money", Resources.money);

        PlayerPrefs.SetInt("PlayerLevel", Resources.playerLevel);
        PlayerPrefs.SetInt("WeaponLevel", Resources.weaponLevel);
        PlayerPrefs.SetInt("PlasticMachineLevel", Resources.plasticMachineLevel);
        PlayerPrefs.SetInt("PaperMachineLevel", Resources.paperMachineLevel);
        PlayerPrefs.SetInt("GlassMachineLevel", Resources.glassMachineLevel);
        PlayerPrefs.SetInt("MetalMachineLevel", Resources.metalMachineLevel);
    }

    public void LoadResources()
    {
        if (PlayerPrefs.GetInt("Plastic") > 0)
        {
            Resources.plastic = PlayerPrefs.GetInt("Plastic");
        }
        if (PlayerPrefs.GetInt("Paper") > 0)
        {
            Resources.paper = PlayerPrefs.GetInt("Paper");
        }
        if (PlayerPrefs.GetInt("Glass") > 0)
        {
            Resources.glass = PlayerPrefs.GetInt("Glass");
        }
        if (PlayerPrefs.GetInt("Metal") > 0)
        {
            Resources.metal = PlayerPrefs.GetInt("Metal");
        }
        if (PlayerPrefs.GetInt("Money") > 0)
        {
            Resources.money = PlayerPrefs.GetInt("Money");
        }

        if (PlayerPrefs.GetInt("PlayerLevel") > 1)
        {
            Resources.playerLevel = PlayerPrefs.GetInt("PlayerLevel");
        }
        if (PlayerPrefs.GetInt("WeaponLevel") > 1)
        {
            Resources.weaponLevel = PlayerPrefs.GetInt("WeaponLevel");
        }
        if (PlayerPrefs.GetInt("PlasticMachineLevel") > 1)
        {
            Resources.plasticMachineLevel = PlayerPrefs.GetInt("PlasticMachineLevel");
        }
        if (PlayerPrefs.GetInt("PaperMachineLevel") > 1)
        {
            Resources.paperMachineLevel = PlayerPrefs.GetInt("PaperMachineLevel");
        }
        if (PlayerPrefs.GetInt("GlassMachineLevel") > 1)
        {
            Resources.glassMachineLevel = PlayerPrefs.GetInt("GlassMachineLevel");
        }
        if (PlayerPrefs.GetInt("MetalMachineLevel") > 1)
        {
            Resources.metalMachineLevel = PlayerPrefs.GetInt("MetalMachineLevel");
        }
    }

    public void ClearResources()
    {
        Resources.plastic = 0;
        Resources.paper = 0;
        Resources.glass = 0;
        Resources.metal = 0;
        Resources.money = 0;

        Resources.playerLevel = 1;
        Resources.weaponLevel = 1;
        Resources.plasticMachineLevel = 1;
        Resources.paperMachineLevel = 1;
        Resources.glassMachineLevel = 1;
        Resources.metalMachineLevel = 1;

        PlayerPrefs.SetInt("Plastic", Resources.plastic);
        PlayerPrefs.SetInt("Paper", Resources.paper);
        PlayerPrefs.SetInt("Glass", Resources.glass);
        PlayerPrefs.SetInt("Metal", Resources.metal);
        PlayerPrefs.SetInt("Money", Resources.money);

        PlayerPrefs.SetInt("PlayerLevel", Resources.playerLevel);
        PlayerPrefs.SetInt("WeaponLevel", Resources.weaponLevel);
        PlayerPrefs.SetInt("PlasticMachineLevel", Resources.plasticMachineLevel);
        PlayerPrefs.SetInt("PaperMachineLevel", Resources.paperMachineLevel);
        PlayerPrefs.SetInt("GlassMachineLevel", Resources.glassMachineLevel);
        PlayerPrefs.SetInt("MetalMachineLevel", Resources.metalMachineLevel);
    }
}
