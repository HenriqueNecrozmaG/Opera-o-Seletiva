using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("CameraSettings")]
    [SerializeField] private Camera mainCamera;

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
    [SerializeField] private BulletInstance bulletPrefab;
    [SerializeField] private Material[] bulletColor;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private float timeToDestroy;
    [SerializeField] private float cooldown;

    public BulletStats plasticBullet;
    public BulletStats paperBullet;
    public BulletStats glassBullet;
    public BulletStats metalBullet;

    private Vector3 target;
    private bool canShoot;
    private SpriteRenderer crosshairsSR;
    private BulletStats bulletType;

    void Start()
    {
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
        plasticBullet = bulletStats.Clone();
        plasticBullet.bulletName = "PlasticBullet";
        plasticBullet.bulletMaterial = bulletColor[0];
        plasticBullet.materialIndex = 0;

        paperBullet = bulletStats.Clone();
        paperBullet.bulletName = "PaperBullet";
        paperBullet.bulletMaterial = bulletColor[1];
        paperBullet.materialIndex = 1;

        glassBullet = bulletStats.Clone();
        glassBullet.bulletName = "GlassBullet";
        glassBullet.bulletMaterial = bulletColor[2];
        glassBullet.materialIndex = 2;

        metalBullet = bulletStats.Clone();
        metalBullet.bulletName = "MetalBullet";
        metalBullet.bulletMaterial = bulletColor[3];
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
        BulletInstance bullet = Instantiate(bulletPrefab);
        bullet.Setup(bulletType);
        bullet.transform.position = bulletPosition.position;
        bullet.transform.rotation = rotation;
        Destroy(bullet.gameObject, timeToDestroy);
    }

    IEnumerator shootCooldown()
    {
        canShoot = false;

        yield return new WaitForSeconds(cooldown);

        canShoot = true;
    }
}