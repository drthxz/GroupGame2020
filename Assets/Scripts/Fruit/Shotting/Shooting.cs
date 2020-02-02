using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int attack;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected GameObject point;
    [SerializeField] protected float disappear;
    [SerializeField] protected float range;
    [SerializeField] protected float timeBetweenBullets = 0.5f;
    protected SphereCollider shootingRange;
    protected bool _shooting;
    [SerializeField] protected GameObject enemy;
    public string type;
    protected Bullet bulletCom;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        bulletCom = bullet.GetComponent<Bullet>();
        bulletCom.disappear = disappear;
        shootingRange = point.AddComponent<SphereCollider>();
        shootingRange.radius = range*10;
        shootingRange.isTrigger = true;
        bulletCom.disappear = disappear;
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_shooting && enemy!=null)
        {
            //transform.LookAt(enemy.transform);
            //transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        }
        if (!_shooting)
        {
            StopAllCoroutines();
        }
    }
}
