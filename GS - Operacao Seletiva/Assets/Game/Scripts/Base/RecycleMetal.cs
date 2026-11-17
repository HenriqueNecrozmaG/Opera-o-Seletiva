using System.Collections;
using UnityEngine;

public class RecycleMetal : MonoBehaviour
{
    [SerializeField] private float recycleTime;
    [SerializeField] private int recycleNumber;
    [SerializeField] private int moneyGained;
    //private bool isRecycling;

    public void MetalRecycle()
    {
        if (Resources.metal > 0)
        {
            print("Começar Reciclagem");
            //isRecycling = true;
            BaseFacade.Instance.DisableUIRecycleMetalButton();
            BaseFacade.Instance.DisableUIUpgradeMetalButton();
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

        Resources.metal -= recycleNumber;
        Resources.money += moneyGained;

        if (Resources.metal > 0)
        {
            print("Reciclou um material");
            BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
            StartCoroutine(RecycleCoroutine());
        }
        else
        {
            print("Reciclagem finalizada");
            Resources.metal = 0;
            //isRecycling = false;
            BaseFacade.Instance.EnableUIRecycleMetalButton();
            BaseFacade.Instance.EnableUIUpgradeMetalButton();
        }
    }
}