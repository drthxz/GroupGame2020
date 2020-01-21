using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotting : MonoBehaviour
{
    public int attack;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected GameObject point;
    [SerializeField] protected float disappear;
    [SerializeField] protected float range;
    [SerializeField] protected float timeBetweenBullets = 0.5f;
    protected SphereCollider shottingRange;
    protected bool _shotting;
    [SerializeField] protected GameObject enemy;
    public string type;
    protected Bullet bulletCom;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        bulletCom = bullet.GetComponent<Bullet>();
        bulletCom.disappear = disappear;
        shottingRange = point.AddComponent<SphereCollider>();
        shottingRange.radius = range*10;
        shottingRange.isTrigger = true;
        bulletCom.disappear = disappear;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_shotting && enemy!=null)
        {
            transform.LookAt(enemy.transform);
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        }
    }
}
