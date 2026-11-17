using System.Collections;
using UnityEngine;

public class RecyclePaper : MonoBehaviour
{
    [SerializeField] private float recycleTime;
    [SerializeField] private int recycleNumber;
    [SerializeField] private int moneyGained;
    //private bool isRecycling;

    public void PaperRecycle()
    {
        if (Resources.paper > 0)
        {
            print("Começar Reciclagem");
            //isRecycling = true;
            BaseFacade.Instance.DisableUIRecyclePaperButton();
            BaseFacade.Instance.DisableUIUpgradePaperButton();
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

        Resources.paper -= recycleNumber;
        Resources.money += moneyGained;

        if (Resources.paper > 0)
        {
            print("Reciclou um material");
            BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
            StartCoroutine(RecycleCoroutine());
        }
        else
        {
            print("Reciclagem finalizada");
            Resources.paper = 0;
            //isRecycling = false;
            BaseFacade.Instance.EnableUIRecyclePaperButton();
            BaseFacade.Instance.EnableUIUpgradePaperButton();
        }
    }
}