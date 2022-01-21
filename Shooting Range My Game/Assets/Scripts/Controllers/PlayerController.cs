using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float bulletSpeed = 100f;
    public int selectedWeapon = 0;

    [SerializeField] private List<WeaponInfo> weaponInfos = new List<WeaponInfo>();
    int currentWeaponIndex;

    GameController GC;
    UIController UI;
    ObjectPooler objectPooler;

    public static PlayerController instance;

    public GameObject bullet;
    public Transform firePosition;
    public Camera cam;

    private GameObject tempBullet;
    private Vector3 bulletDirection;

    public GameObject weapon1;
    public GameObject weapon2;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartMethods();
    }

    #region Start Methods

    void StartMethods()
    {
        GetGameController();
    }

    void GetGameController()
    {
        GC = GameController.instance;
        UI = UIController.instance;
        objectPooler = ObjectPooler.instance;
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (GC.gameState == GameController.GameStates.Start)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                //GameObject bullet1 = Instantiate(bullet);
                //bullet1.transform.position = firePosition.transform.position + firePosition.transform.forward;
                //bullet1.transform.forward = firePosition.transform.forward;
                Shoot();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                SelectWeapon();

            }

        }
    }

    void Shoot()
    {
        
        Ray ray = cam.ViewportPointToRay(new Vector3(0, 0, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            bulletDirection = hit.point;
        }
        else
        {
            bulletDirection = ray.GetPoint(1000);
        }

        tempBullet = objectPooler.SpawnFromPool(weaponInfos[currentWeaponIndex].bulletName, firePosition.position, Quaternion.identity);
        tempBullet.GetComponent<BulletController>().GetInfos(bulletDirection, weaponInfos[currentWeaponIndex]);
        Debug.Log("Fired");
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    /*public void onObjectSpawn()
    {
        RaycastHit hit;
        if (Physics.Raycast(firePosition.transform.position, firePosition.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GetComponent<Rigidbody>().velocity = Vector3.forward * bulletSpeed;
        }
    }



    /*public float damage = 10f;

    public Camera playerCam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hitInfo))
        {
            Debug.Log(hitInfo.transform.name);

            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

    }
    */
}