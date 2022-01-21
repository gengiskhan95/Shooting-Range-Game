using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody rb;
    private WeaponInfo weaponInfo;
    private Vector3 direction;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.velocity = direction * weaponInfo.speed;
    }
    public void GetInfos(Vector3 _direction, WeaponInfo _weaponInfo)
    {
        this.direction = _direction;
        this.weaponInfo = _weaponInfo;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Hit!");
        }

        BackToThePool();

    }

    void BackToThePool()
    {
        ObjectPooler.instance.BackToThePool(gameObject, weaponInfo.bulletName);
    }
}
