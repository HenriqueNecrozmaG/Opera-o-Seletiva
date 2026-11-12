using Unity.VisualScripting;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    public static GameFacade Instance { get; private set; }

    [Header("Managers")]
    [SerializeField] private UIManager uiManager;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
    }

    public void StartGame()
    {
        uiManager.ShowHUD();
    }

    public void UpdateUIMaterialText(string text, Color color)
    {
        uiManager.UpdateMaterialText(text, color);
    }

    public void UpdateUIHealthBar(float currentHealth, float maxHealth)
    {
        uiManager.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void UpdateUIMaterialQuantityTexts(int plasticQuantity, int paperQuantity, int glassQuantity, int metalQuantity)
    {
        uiManager.UpdateMaterialQuantityTexts(plasticQuantity, paperQuantity, glassQuantity, metalQuantity);
    }

    public void UpdateUIMaterialQuantityVictoryTexts(int plasticQuantity, int paperQuantity, int glassQuantity, int metalQuantity)
    {
        uiManager.UpdateMaterialQuantityVictoryTexts(plasticQuantity, paperQuantity, glassQuantity, metalQuantity);
    }

    public void UpdateUITextTime(int time)
    {
        uiManager.UpdateTextTime(time);
    }

    public void ShowUIPausePanel()
    {
        uiManager.ShowPausePanel();
    }

    public void HideUIPausePanel()
    {
        uiManager.HidePausePanel();
    }

    public void ShowUIVictoryPanel()
    {
        uiManager.ShowVictoryPanel();
    }

    public void ShowUIDefeatPanel()
    {
        uiManager.ShowDefeatPanel();
    }
}
