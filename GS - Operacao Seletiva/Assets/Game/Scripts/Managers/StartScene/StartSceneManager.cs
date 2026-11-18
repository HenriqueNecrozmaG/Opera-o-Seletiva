using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartSceneManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private GameObject panelOptions;
    [SerializeField] private GameObject panelConfirm;

    void Awake()
    {
        LoadResources();
    }

    void Start()
    {
        musicManager.Play(0);
        panelOptions.SetActive(false);
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

    public void Quit()
    {
        SaveResources();
        audioManager.PlaySoundEffect(0);
        StartCoroutine(QuitCoroutine());
    }

    IEnumerator QuitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        Application.Quit();
    }

    public void ClearProgress()
    {
        ClearResources();
        audioManager.PlaySoundEffect(0);
        panelConfirm.SetActive(true);
    }

    public void ConfirmClear()
    {
        audioManager.PlaySoundEffect(0);
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
        Resources.plastic = PlayerPrefs.GetInt("Plastic");
        Resources.paper = PlayerPrefs.GetInt("Paper");
        Resources.glass = PlayerPrefs.GetInt("Glass");
        Resources.metal = PlayerPrefs.GetInt("Metal");
        Resources.money = PlayerPrefs.GetInt("Money");

        Resources.playerLevel = PlayerPrefs.GetInt("PlayerLevel");
        Resources.weaponLevel = PlayerPrefs.GetInt("WeaponLevel");
        Resources.plasticMachineLevel = PlayerPrefs.GetInt("PlasticMachineLevel");
        Resources.paperMachineLevel = PlayerPrefs.GetInt("PaperMachineLevel");
        Resources.glassMachineLevel = PlayerPrefs.GetInt("GlassMachineLevel");
        Resources.metalMachineLevel = PlayerPrefs.GetInt("MetalMachineLevel");
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
