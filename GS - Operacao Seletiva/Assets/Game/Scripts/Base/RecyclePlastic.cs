using System.Collections;
using UnityEngine;

public class RecyclePlastic : MonoBehaviour
{
    [SerializeField] private float recycleTime;
    [SerializeField] private int recycleNumber;
    [SerializeField] private int moneyGained;
    private bool isRecycling;

    public void PlasticRecycle()
    {
        if (Resources.plastic > 0)
        {
            StartCoroutine(RecycleCoroutine());
        }
    }

    IEnumerator RecycleCoroutine()
    {
        yield return new WaitForSeconds(recycleTime);

        Resources.plastic -= recycleNumber;
        Resources.money += moneyGained;

        if (Resources.plastic > 0)
        {
            StartCoroutine(RecycleCoroutine());
        }
    }
}
