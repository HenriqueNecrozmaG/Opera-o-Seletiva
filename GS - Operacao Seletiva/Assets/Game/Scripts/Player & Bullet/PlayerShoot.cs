using System.Collections;
using TMPro;
using UnityEditor.Compilation;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] private GameObject crosshairs;
    [SerializeField] private Sprite[] crosshairsSprites;
    [SerializeField] private GameObject weapon;
    [SerializeField] private MeshRenderer weaponRender;
    [SerializeField] private Material[] weaponColor;
    [SerializeField] private float sensibilityX;
    [SerializeField] private float sensibilityY;

    [Header("Bullet Settings")]
    [SerializeField] private BulletStats bulletStats;
    [SerializeField] private BulletInstance[] bulletPrefab;
    [SerializeField] private Material[] bulletColorLvl1;
    [SerializeField] private Material[] bulletColorLvl2;
    [SerializeField] private Material[] bulletColorLvl3;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private float timeToDestroy;
    [SerializeField] private float cooldown;

    public BulletStats plasticBullet;
    public BulletStats paperBullet;
    public BulletStats glassBullet;
    public BulletStats metalBullet;

    private Camera mainCamera;
    private Vector3 target;
    private bool canShoot;
    private SpriteRenderer crosshairsSR;
    private BulletStats bulletType;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        SetBullets();
        canShoot = true;
        crosshairsSR = crosshairs.GetComponent<SpriteRenderer>();

        crosshairsSR.sprite = crosshairsSprites[0];
        bulletType = plasticBullet;
        GameFacade.Instance.UpdateUIMaterialText("Plástico", Color.red);
        weaponRender.material = weaponColor[0];
    }

    void SetBullets()
    {
        ///PLASTIC BULLET///
        plasticBullet = bulletStats.Clone();
        plasticBullet.bulletName = "PlasticBullet";
        
        if (Resources.weaponLevel == 1)
        {
            plasticBullet.bulletMaterial = bulletColorLvl1[0];
        }
        else if (Resources.weaponLevel == 2)
        {
            plasticBullet.bulletMaterial = bulletColorLvl2[0];
        }
        else if (Resources.weaponLevel == 3)
        {
            plasticBullet.bulletMaterial = bulletColorLvl3[0];
        }

        plasticBullet.materialIndex = 0;

        ///PAPER BULLET///
        paperBullet = bulletStats.Clone();
        paperBullet.bulletName = "PaperBullet";

        if (Resources.weaponLevel == 1)
        {
            paperBullet.bulletMaterial = bulletColorLvl1[1];
        }
        else if (Resources.weaponLevel == 2)
        {
            paperBullet.bulletMaterial = bulletColorLvl2[1];
        }
        else if (Resources.weaponLevel == 3)
        {
            paperBullet.bulletMaterial = bulletColorLvl3[1];
        }

        paperBullet.materialIndex = 1;

        ///GLASS BULLET///
        glassBullet = bulletStats.Clone();
        glassBullet.bulletName = "GlassBullet";

        if (Resources.weaponLevel == 1)
        {
            glassBullet.bulletMaterial = bulletColorLvl1[2];
        }
        else if (Resources.weaponLevel == 2)
        {
            glassBullet.bulletMaterial = bulletColorLvl2[2];
        }
        else if (Resources.weaponLevel == 3)
        {
            glassBullet.bulletMaterial = bulletColorLvl3[2];
        }

        glassBullet.materialIndex = 2;

        ///METAL BULLET///
        metalBullet = bulletStats.Clone();
        metalBullet.bulletName = "MetalBullet";

        if (Resources.weaponLevel == 1)
        {
            metalBullet.bulletMaterial = bulletColorLvl1[3];
        }
        else if (Resources.weaponLevel == 2)
        {
            metalBullet.bulletMaterial = bulletColorLvl2[3];
        }
        else if (Resources.weaponLevel == 3)
        {
            metalBullet.bulletMaterial = bulletColorLvl3[3];
        }

        metalBullet.materialIndex = 3;
    }

    void Update()
    {
        if (GameManager.Instance.CurrentState == GameState.Paused || GameManager.Instance.CurrentState == GameState.Victory)
        {
            return;
        }

        Aim();
        ChangeWeapon();
        Shoot();
    }

    void Aim()
    {
        target = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, +10f));
        crosshairs.transform.position = target;

        weapon.transform.rotation = Quaternion.Euler(-target.y * sensibilityY, target.x * sensibilityX, 0.0f);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            ShootBullet(weapon.transform.rotation, bulletType);
            StartCoroutine(shootCooldown());
        }
    }

    void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            crosshairsSR.sprite = crosshairsSprites[0];
            bulletType = plasticBullet;
            GameFacade.Instance.UpdateUIMaterialText("Plástico", Color.red);
            weaponRender.material = weaponColor[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            crosshairsSR.sprite = crosshairsSprites[1];
            bulletType = paperBullet;
            GameFacade.Instance.UpdateUIMaterialText("Papel", Color.blue);
            weaponRender.material = weaponColor[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            crosshairsSR.sprite = crosshairsSprites[2];
            bulletType = glassBullet;
            GameFacade.Instance.UpdateUIMaterialText("Vidro", Color.green);
            weaponRender.material = weaponColor[2];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            crosshairsSR.sprite = crosshairsSprites[3];
            bulletType = metalBullet;
            GameFacade.Instance.UpdateUIMaterialText("Metal", Color.yellow);
            weaponRender.material = weaponColor[3];
        }
    }

    void ShootBullet(Quaternion rotation, BulletStats bulletType)
    {
        BulletInstance bullet = null;

        if (Resources.weaponLevel == 1)
        {
            bullet = Instantiate(bulletPrefab[0]);
        }
        else if (Resources.weaponLevel == 2)
        {
            bullet = Instantiate(bulletPrefab[1]);
        }
        else if (Resources.weaponLevel == 3)
        {
            bullet = Instantiate(bulletPrefab[2]);
        }

        bullet.Setup(bulletType);
        bullet.transform.position = bulletPosition.position;
        bullet.transform.rotation = rotation;
        GameFacade.Instance.PlayAudioSoundEffect(8);
        Destroy(bullet.gameObject, timeToDestroy);
    }

    IEnumerator shootCooldown()
    {
        canShoot = false;

        yield return new WaitForSeconds(cooldown);

        canShoot = true;
    }
}