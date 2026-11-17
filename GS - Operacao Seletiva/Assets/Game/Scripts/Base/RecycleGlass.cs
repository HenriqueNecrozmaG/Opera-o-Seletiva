using System.Collections;
using UnityEngine;

public class RecycleGlass : MonoBehaviour
{
    [SerializeField] private float recycleTime;
    [SerializeField] private int recycleNumber;
    [SerializeField] private int moneyGained;
    //private bool isRecycling;

    public void GlassRecycle()
    {
        if (Resources.glass > 0)
        {
            print("Começar Reciclagem");
            //isRecycling = true;
            BaseFacade.Instance.DisableUIRecycleGlassButton();
            BaseFacade.Instance.DisableUIUpgradeGlassButton();
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

        Resources.glass -= recycleNumber;
        Resources.money += moneyGained;

        if (Resources.glass > 0)
        {
            print("Reciclou um material");
            BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
            StartCoroutine(RecycleCoroutine());
        }
        else
        {
            print("Reciclagem finalizada");
            Resources.glass = 0;
            //isRecycling = false;
            BaseFacade.Instance.EnableUIRecycleGlassButton();
            BaseFacade.Instance.EnableUIUpgradeGlassButton();
        }
    }
}