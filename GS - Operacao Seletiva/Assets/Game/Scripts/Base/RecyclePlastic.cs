using System.Collections;
using UnityEngine;

public class RecyclePlastic : MonoBehaviour
{
    [SerializeField] private float recycleTime;
    [SerializeField] private int recycleNumber;
    [SerializeField] private int moneyGained;
    //private bool isRecycling;

    public void PlasticRecycle()
    {
        if (Resources.plastic > 0)
        {
            print("Começar Reciclagem");
            //isRecycling = true;
            BaseFacade.Instance.DisableUIRecyclePlasticButton();
            BaseFacade.Instance.DisableUIUpgradePlasticButton();
            StartCoroutine(RecycleCoroutine());
        }
        else
        {
            BaseFacade.Instance.ShowUIMaterialMessagePanel();
        }
    }

    IEnumerator RecycleCoroutine()
    {
        print("Reciclando");
        yield return new WaitForSeconds(recycleTime);

        Resources.plastic -= recycleNumber;
        Resources.money += moneyGained;

        if (Resources.plastic > 0)
        {
            print("Reciclou um material");
            BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
            StartCoroutine(RecycleCoroutine());
        }
        else
        {
            print("Reciclagem finalizada");
            Resources.plastic = 0;
            //isRecycling = false;
            BaseFacade.Instance.EnableUIRecyclePlasticButton();
            BaseFacade.Instance.EnableUIUpgradePlasticButton();
        }
    }
}