using System.Collections;
using UnityEngine;

public class RecycleMetal : MonoBehaviour
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

    public void MetalRecycle()
    {
        if (Resources.metal > 0)
        {
            BaseFacade.Instance.PlayAudioSoundEffect(2);
            isRecycling = true;
            BaseFacade.Instance.DisableUIRecycleMetalButton();
            BaseFacade.Instance.DisableUIUpgradeMetalButton();
            StartCoroutine(RecycleCoroutine());
            progress = 0;
            StartCoroutine(Progress());
            BaseFacade.Instance.EnableUISliderMetal();
        }
        else
        {
            BaseFacade.Instance.PlayAudioSoundEffect(0);
            BaseFacade.Instance.ShowUIMaterialMessagePanel();
        }
    }

    IEnumerator RecycleCoroutine()
    {
        yield return new WaitForSeconds(recycleTime);

        Resources.metal -= recycleNumber;
        Resources.money += moneyGained;
        BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
        BaseFacade.Instance.PlayAudioSoundEffect(3);

        if (Resources.metal > 0)
        {
            yield return new WaitForSeconds(0.01f);

            StartCoroutine(RecycleCoroutine());
            progress = 0;
            StartCoroutine(Progress());
        }
        else
        {
            Resources.metal = 0;
            isRecycling = false;
            BaseFacade.Instance.EnableUIRecycleMetalButton();
            BaseFacade.Instance.EnableUIUpgradeMetalButton();
            BaseFacade.Instance.DisableUISliderMetal();
            progress = 0;
        }
    }

    IEnumerator Progress()
    {
        yield return new WaitForSeconds(1);
        progress++;
        value = progress / recycleTime;
        BaseFacade.Instance.UpdateUISliderMetal(value);

        if (progress < recycleTime)
        {
            StartCoroutine(Progress());
        }
    }
}