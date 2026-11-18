using System.Collections;
using UnityEngine;

public class RecycleGlass : MonoBehaviour
{
    [SerializeField] private float recycleTime;
    [SerializeField] private int recycleNumber;
    [SerializeField] private int moneyGained;

    private Animator anim;

    private int progress;
    private float value;
    private bool isRecycling;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("pRecycling", isRecycling);
    }

    public void GlassRecycle()
    {
        if (Resources.glass > 0)
        {
            isRecycling = true;
            BaseFacade.Instance.DisableUIRecycleGlassButton();
            BaseFacade.Instance.DisableUIUpgradeGlassButton();
            StartCoroutine(RecycleCoroutine());
            progress = 0;
            StartCoroutine(Progress());
            BaseFacade.Instance.EnableUISliderGlass();
        }
        else
        {
            BaseFacade.Instance.ShowUIMaterialMessagePanel();
        }
    }

    IEnumerator RecycleCoroutine()
    {
        yield return new WaitForSeconds(recycleTime);

        Resources.glass -= recycleNumber;
        Resources.money += moneyGained;
        BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
        BaseFacade.Instance.PlayAudioSoundEffect(3);

        if (Resources.glass > 0)
        {
            yield return new WaitForSeconds(0.01f);

            StartCoroutine(RecycleCoroutine());
            progress = 0;
            StartCoroutine(Progress());
        }
        else
        {
            Resources.glass = 0;
            isRecycling = false;
            BaseFacade.Instance.EnableUIRecycleGlassButton();
            BaseFacade.Instance.EnableUIUpgradeGlassButton();
            BaseFacade.Instance.DisableUISliderGlass();
            progress = 0;
        }
    }

    IEnumerator Progress()
    {
        yield return new WaitForSeconds(1);
        progress++;
        value = progress / recycleTime;
        BaseFacade.Instance.UpdateUISliderGlass(value);

        if (progress < recycleTime)
        {
            StartCoroutine(Progress());
        }
    }
}