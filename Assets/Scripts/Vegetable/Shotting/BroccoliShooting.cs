using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroccoliShooting : Shooting
{
    public new Transform[] pointRotation = new Transform[4];
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < 4; i++)
        {
            pointRotation[i] = transform.GetChild(1);
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var temp = other.gameObject.GetComponent<Health>();
        if (temp && temp.type == "Fruit")
        {
            enemy = other.gameObject;
            _shooting = true;
            StartCoroutine(Shotting(timeBetweenBullets));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var temp = other.gameObject.GetComponent<Health>();
        if (temp && temp.type == "Fruit")
        {
            _shooting = false;
            StopCoroutine(Shotting(timeBetweenBullets));
        }
    }

    IEnumerator Shotting(float time)
    {

        while (_shooting)
        {
            yield return new WaitForSeconds(time);
            bulletCom.type = type;
            bulletCom.attack = attack;
            GameObject temp = Instantiate(bullet, point.transform.position, new Quaternion(0f,0f,0f,0f));
            temp.GetComponent<Rigidbody>().velocity = (point.transform.forward * 10f);
            for (int i = 0; i < 4; i++)
            {
                if (pointRotation[i] != null)
                {
                    pointRotation[i].localRotation = Quaternion.Euler (0, 180 - transform.parent.rotation.eulerAngles.y, 0);//transform.rotation;
                }
            }
        }
    }
}
