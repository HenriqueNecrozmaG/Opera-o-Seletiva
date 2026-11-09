using System.Collections;
using TMPro;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    [Header("CameraSettings")]
    [SerializeField] private Camera mainCamera;

    [Header("Weapon Settings")]
    [SerializeField] private GameObject crosshairs;
    [SerializeField] private GameObject weapon;
    [SerializeField] private float sensibilityX;
    [SerializeField] private float sensibilityY;
    [SerializeField] private float yOffset;

    [Header("Bullet Settings")]
    [SerializeField] private BulletStats bulletStats;
    [SerializeField] private BulletInstance bulletPrefab;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private float timeToDestroy;
    [SerializeField] private float cooldown;

    [Header("UI Settings")]
    [SerializeField] private TextMeshProUGUI textMaterial;

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
        Cursor.visible = false;
        canShoot = true;
        crosshairsSR = crosshairs.GetComponent<SpriteRenderer>();
        weaponRender = weapon.GetComponent<MeshRenderer>();

        crosshairsSR.color = Color.red;
        bulletType = plasticBullet;
        textMaterial.text = "Plástico";
        textMaterial.color = Color.red;
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
        target = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + yOffset, +10f));
        crosshairs.transform.position = target;

        weapon.transform.rotation = Quaternion.Euler(-target.y * sensibilityY, target.x * sensibilityX, 0.0f);

        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            ShootBullet(weapon.transform.rotation, bulletType);
            StartCoroutine(shootCooldown());
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            crosshairsSR.color = Color.red;
            bulletType = plasticBullet;
            textMaterial.text = "Plástico";
            textMaterial.color = Color.red;
            weaponRender.material.color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            crosshairsSR.color = Color.blue;
            bulletType = paperBullet;
            textMaterial.text = "Papel";
            textMaterial.color = Color.blue;
            weaponRender.material.color = Color.blue;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            crosshairsSR.color = Color.green;
            bulletType = glassBullet;
            textMaterial.text = "Vidro";
            textMaterial.color = Color.green;
            weaponRender.material.color = Color.green;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            crosshairsSR.color = Color.yellow;
            bulletType = metalBullet;
            textMaterial.text = "Metal";
            textMaterial.color = Color.yellow;
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