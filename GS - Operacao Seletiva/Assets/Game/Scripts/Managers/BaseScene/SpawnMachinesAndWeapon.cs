using UnityEngine;

public class SpawnMachinesAndWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] plasticMachinePrefab;
    [SerializeField] private GameObject[] paperMachinePrefab;
    [SerializeField] private GameObject[] glassMachinePrefab;
    [SerializeField] private GameObject[] metalMachinePrefab;
    [SerializeField] private GameObject[] weaponPrefab;

    private GameObject plasticMachine;
    private GameObject paperMachine;
    private GameObject glassMachine;
    private GameObject metalMachine;
    private GameObject weapon;

    private RecyclePlastic plasticRecyclingScript;
    private RecyclePaper paperRecyclingScript;
    private RecycleGlass glassRecyclingScript;
    private RecycleMetal metalRecyclingScript;

    public void SpawnPlasticMachine()
    {
        if (Resources.plasticMachineLevel == 1)
        {
            plasticMachine = Instantiate(plasticMachinePrefab[0]);
            plasticMachine.transform.position = plasticMachinePrefab[0].transform.position;
        }
        else if (Resources.plasticMachineLevel == 2)
        {
            plasticMachine = Instantiate(plasticMachinePrefab[1]);
            plasticMachine.transform.position = plasticMachinePrefab[1].transform.position;
        }
        else if (Resources.plasticMachineLevel == 3)
        {
            plasticMachine = Instantiate(plasticMachinePrefab[2]);
            plasticMachine.transform.position = plasticMachinePrefab[2].transform.position;
        }

        plasticRecyclingScript = plasticMachine.GetComponent<RecyclePlastic>();
    }

    public void SpawnPaperMachine()
    {
        if (Resources.paperMachineLevel == 1)
        {
            paperMachine = Instantiate(paperMachinePrefab[0]);
            paperMachine.transform.position = paperMachinePrefab[0].transform.position;
        }
        else if (Resources.paperMachineLevel == 2)
        {
            paperMachine = Instantiate(paperMachinePrefab[1]);
            paperMachine.transform.position = paperMachinePrefab[1].transform.position;
        }
        else if (Resources.paperMachineLevel == 3)
        {
            paperMachine = Instantiate(paperMachinePrefab[2]);
            paperMachine.transform.position = paperMachinePrefab[2].transform.position;
        }

        paperRecyclingScript = paperMachine.GetComponent<RecyclePaper>();
    }

    public void SpawnGlassMachine()
    {
        if (Resources.glassMachineLevel == 1)
        {
            glassMachine = Instantiate(glassMachinePrefab[0]);
            glassMachine.transform.position = glassMachinePrefab[0].transform.position;
        }
        else if (Resources.glassMachineLevel == 2)
        {
            glassMachine = Instantiate(glassMachinePrefab[1]);
            glassMachine.transform.position = glassMachinePrefab[1].transform.position;
        }
        else if (Resources.glassMachineLevel == 3)
        {
            glassMachine = Instantiate(glassMachinePrefab[2]);
            glassMachine.transform.position = glassMachinePrefab[2].transform.position;
        }

        glassRecyclingScript = glassMachine.GetComponent<RecycleGlass>();
    }

    public void SpawnMetalMachine()
    {
        if (Resources.metalMachineLevel == 1)
        {
            metalMachine = Instantiate(metalMachinePrefab[0]);
            metalMachine.transform.position = metalMachinePrefab[0].transform.position;
        }
        else if (Resources.metalMachineLevel == 2)
        {
            metalMachine = Instantiate(metalMachinePrefab[1]);
            metalMachine.transform.position = metalMachinePrefab[1].transform.position;
        }
        else if (Resources.metalMachineLevel == 3)
        {
            metalMachine = Instantiate(metalMachinePrefab[2]);
            metalMachine.transform.position = metalMachinePrefab[2].transform.position;
        }

        metalRecyclingScript = metalMachine.GetComponent<RecycleMetal>();
    }
    
    public void SpawnWeapon()
    {
        if (Resources.weaponLevel == 1)
        {
            weapon = Instantiate(weaponPrefab[0]);
            weapon.transform.position = weaponPrefab[0].transform.position;
        }
        else if (Resources.weaponLevel == 2)
        {
            weapon = Instantiate(weaponPrefab[1]);
            weapon.transform.position = weaponPrefab[1].transform.position;
        }
        else if (Resources.weaponLevel == 3)
        {
            weapon = Instantiate(weaponPrefab[2]);
            weapon.transform.position = weaponPrefab[2].transform.position;
        }
    }

    public void UpgradePlasticMachine()
    {
        if (Resources.plasticMachineLevel == 2)
        {
            Destroy(plasticMachine);
            plasticMachine = Instantiate(plasticMachinePrefab[1]);
            plasticMachine.transform.position = plasticMachinePrefab[1].transform.position;
        }
        else if (Resources.plasticMachineLevel == 3)
        {
            Destroy(plasticMachine);
            plasticMachine = Instantiate(plasticMachinePrefab[2]);
            plasticMachine.transform.position = plasticMachinePrefab[2].transform.position;
        }

        plasticRecyclingScript = plasticMachine.GetComponent<RecyclePlastic>();
    }

    public void UpgradePaperMachine()
    {
        if (Resources.paperMachineLevel == 2)
        {
            Destroy(paperMachine);
            paperMachine = Instantiate(paperMachinePrefab[1]);
            paperMachine.transform.position = paperMachinePrefab[1].transform.position;
        }
        else if (Resources.paperMachineLevel == 3)
        {
            Destroy(paperMachine);
            paperMachine = Instantiate(paperMachinePrefab[2]);
            paperMachine.transform.position = paperMachinePrefab[2].transform.position;
        }

        paperRecyclingScript = paperMachine.GetComponent<RecyclePaper>();
    }

    public void UpgradeGlassMachine()
    {
        if (Resources.glassMachineLevel == 2)
        {
            Destroy(glassMachine);
            glassMachine = Instantiate(glassMachinePrefab[1]);
            glassMachine.transform.position = glassMachinePrefab[1].transform.position;
        }
        else if (Resources.glassMachineLevel == 3)
        {
            Destroy(glassMachine);
            glassMachine = Instantiate(glassMachinePrefab[2]);
            glassMachine.transform.position = glassMachinePrefab[2].transform.position;
        }

        glassRecyclingScript = glassMachine.GetComponent<RecycleGlass>();
    }

    public void UpgradeMetalMachine()
    {
        if (Resources.metalMachineLevel == 2)
        {
            Destroy(metalMachine);
            metalMachine = Instantiate(metalMachinePrefab[1]);
            metalMachine.transform.position = metalMachinePrefab[1].transform.position;
        }
        else if (Resources.metalMachineLevel == 3)
        {
            Destroy(metalMachine);
            metalMachine = Instantiate(metalMachinePrefab[2]);
            metalMachine.transform.position = metalMachinePrefab[2].transform.position;
        }

        metalRecyclingScript = metalMachine.GetComponent<RecycleMetal>();
    }

    public void UpgradeWeapon()
    {
        if (Resources.weaponLevel == 2)
        {
            Destroy(weapon);
            weapon = Instantiate(weaponPrefab[1]);
            weapon.transform.position = weaponPrefab[1].transform.position;
        }
        else if (Resources.weaponLevel == 3)
        {
            Destroy(weapon);
            weapon = Instantiate(weaponPrefab[2]);
            weapon.transform.position = weaponPrefab[2].transform.position;
        }
    }

    public void PlasticRecycle()
    {
        plasticRecyclingScript.PlasticRecycle();
    }

    public void PaperRecycle()
    {
        paperRecyclingScript.PaperRecycle();
    }

    public void GlassRecycle()
    {
        glassRecyclingScript.GlassRecycle();
    }

    public void MetalRecycle()
    {
        metalRecyclingScript.MetalRecycle();
    }
}
