using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroccoliShotting : Shotting
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
            _shotting = true;
            StartCoroutine(Shotting(timeBetweenBullets));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var temp = other.gameObject.GetComponent<Health>();
        if (temp && temp.type == "Fruit")
        {
            _shotting = false;
            StopCoroutine(Shotting(timeBetweenBullets));
        }
    }

    IEnumerator Shotting(float time)
    {

        while (_shotting)
        {
            yield return new WaitForSeconds(time);
            bulletCom.type = type;
            bulletCom.attack = attack;
            GameObject temp = Instantiate(bullet, point.transform.position, new Quaternion(0f,0f,0f,0f));
            temp.GetComponent<Rigidbody>().velocity = (point.transform.forward * 10f);
        }
    }
}
