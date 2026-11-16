using UnityEngine;

public class MoveCameraBase : MonoBehaviour
{
    private bool plasticEnabled;
    private bool paperEnabled;
    private bool glassEnabled;
    private bool metalEnabled;
    private bool weaponEnabled;

    void Start()
    {
        transform.position = new Vector3(5, 2, -10);
        
        plasticEnabled = true;
        paperEnabled = false;
        glassEnabled = false;
        metalEnabled = false;
        weaponEnabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            BaseFacade.Instance.PlayAudioSoundEffect(0);

            if (transform.position.x < 73)
            {
                transform.position = new Vector3(transform.position.x + 17, transform.position.y, transform.position.z);
            }

            if (plasticEnabled)
            {
                BaseFacade.Instance.ShowUIPaperPanel();
                plasticEnabled = false;
                paperEnabled = true;
            }
            else if (paperEnabled)
            {
                BaseFacade.Instance.ShowUIGlassPanel();
                paperEnabled = false;
                glassEnabled = true;
            }
            else if (glassEnabled)
            {
                BaseFacade.Instance.ShowUIMetalPanel();
                glassEnabled = false;
                metalEnabled = true;
            }
            else if (metalEnabled)
            {
                BaseFacade.Instance.ShowUIWeaponPanel();
                metalEnabled = false;
                weaponEnabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            BaseFacade.Instance.PlayAudioSoundEffect(0);

            if (transform.position.x > 5)
            {
                transform.position = new Vector3(transform.position.x - 17, transform.position.y, transform.position.z);
            }

            if (paperEnabled)
            {
                BaseFacade.Instance.ShowUIPlasticPanel();
                paperEnabled = false;
                plasticEnabled = true;
            }
            else if (glassEnabled)
            {
                BaseFacade.Instance.ShowUIPaperPanel();
                glassEnabled = false;
                paperEnabled = true;
            }
            else if (metalEnabled)
            {
                BaseFacade.Instance.ShowUIGlassPanel();
                metalEnabled = false;
                glassEnabled = true;
            }
            else if (weaponEnabled)
            {
                BaseFacade.Instance.ShowUIMetalPanel();
                weaponEnabled = false;
                metalEnabled = true;
            }
        }
    }
}
