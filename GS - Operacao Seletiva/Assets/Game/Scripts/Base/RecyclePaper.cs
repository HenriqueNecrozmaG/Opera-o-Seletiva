using System.Collections;
using UnityEngine;

public class RecyclePaper : MonoBehaviour
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

    public void PaperRecycle()
    {
        if (Resources.paper > 0)
        {
            BaseFacade.Instance.PlayAudioSoundEffect(2);
            isRecycling = true;
            BaseFacade.Instance.DisableUIRecyclePaperButton();
            BaseFacade.Instance.DisableUIUpgradePaperButton();
            StartCoroutine(RecycleCoroutine());
            progress = 0;
            StartCoroutine(Progress());
            BaseFacade.Instance.EnableUISliderPaper();
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

        Resources.paper -= recycleNumber;
        Resources.money += moneyGained;
        BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
        BaseFacade.Instance.PlayAudioSoundEffect(3);

        if (Resources.paper > 0)
        {
            yield return new WaitForSeconds(0.01f);

            StartCoroutine(RecycleCoroutine());
            progress = 0;
            StartCoroutine(Progress());
        }
        else
        {
            Resources.paper = 0;
            isRecycling = false;
            BaseFacade.Instance.EnableUIRecyclePaperButton();
            BaseFacade.Instance.EnableUIUpgradePaperButton();
            BaseFacade.Instance.DisableUISliderPaper();
            progress = 0;
        }
    }

    IEnumerator Progress()
    {
        yield return new WaitForSeconds(1);
        progress++;
        value = progress / recycleTime;
        BaseFacade.Instance.UpdateUISliderPaper(value);

        if (progress < recycleTime)
        {
            StartCoroutine(Progress());
        }
    }
}