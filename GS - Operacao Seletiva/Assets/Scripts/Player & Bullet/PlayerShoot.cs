using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("CameraSettings")]
    [SerializeField] private Camera mainCamera;

    [Header("Weapon Settings")]
    [SerializeField] private GameObject crosshairs;
    [SerializeField] private GameObject weapon;
    [SerializeField] private float sensibilityX;
    [SerializeField] private float sensibilityY;

    [Header("Bullet Settings")]
    [SerializeField] private BulletStats bulletStats;
    [SerializeField] private BulletInstance bulletPrefab;
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
    private MeshRenderer weaponRender;

    void Start()
    {
        SetBullets();
        canShoot = true;
        crosshairsSR = crosshairs.GetComponent<SpriteRenderer>();
        weaponRender = weapon.GetComponent<MeshRenderer>();

        crosshairsSR.color = Color.red;
        bulletType = plasticBullet;
        GameFacade.Instance.UpdateUIMaterialText("Plástico", Color.red);
        weaponRender.material.color = Color.red;
    }

    void SetBullets()
    {
        plasticBullet = bulletStats.Clone();
        plasticBullet.bulletName = "PlasticBullet";
        plasticBullet.bulletColor = Color.red;
        plasticBullet.materialIndex = 0;

        paperBullet = bulletStats.Clone();
        paperBullet.bulletName = "PaperBullet";
        paperBullet.bulletColor = Color.blue;
        paperBullet.materialIndex = 1;

        glassBullet = bulletStats.Clone();
        glassBullet.bulletName = "GlassBullet";
        glassBullet.bulletColor = Color.green;
        glassBullet.materialIndex = 2;

        metalBullet = bulletStats.Clone();
        metalBullet.bulletName = "MetalBullet";
        metalBullet.bulletColor = Color.yellow;
        metalBullet.materialIndex = 3;
    }

    void Update()
    {
        if (GameManager.Instance.CurrentState == GameState.Paused)
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
            crosshairsSR.color = Color.red;
            bulletType = plasticBullet;
            GameFacade.Instance.UpdateUIMaterialText("Plástico", Color.red);
            weaponRender.material.color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            crosshairsSR.color = Color.blue;
            bulletType = paperBullet;
            GameFacade.Instance.UpdateUIMaterialText("Papel", Color.blue);
            weaponRender.material.color = Color.blue;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            crosshairsSR.color = Color.green;
            bulletType = glassBullet;
            GameFacade.Instance.UpdateUIMaterialText("Vidro", Color.green);
            weaponRender.material.color = Color.green;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            crosshairsSR.color = Color.yellow;
            bulletType = metalBullet;
            GameFacade.Instance.UpdateUIMaterialText("Metal", Color.yellow);
            weaponRender.material.color = Color.yellow;
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