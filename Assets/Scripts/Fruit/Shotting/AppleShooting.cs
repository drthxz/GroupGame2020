using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleShooting : Shooting
{
    private int seedCound=6;
    private bool speedup;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //StartCoroutine(Shotting(timeBetweenBullets));
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (enemy != null)
        {
            
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            
            if (distance < range && !speedup)
            {
                speedup = true;
                StartCoroutine(Shooting(timeBetweenBullets));
            }
        }else{
            enemy=gameObject.GetComponent<Move>().tempTarget;
            _shooting = false;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        var temp = other.gameObject.GetComponent<Health>();
        if (temp && temp.type == "Vegetable")
        {
            enemy = other.gameObject;
            _shooting = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var temp = other.gameObject.GetComponent<Health>();
        if (temp && temp.type == "Vegetable")
        {
            _shooting = false;
            speedup = false;
        }
    }

    IEnumerator Shooting(float time)
    {
        GameObject []temp=new GameObject[seedCound];
        while (_shooting)
        {
            yield return new WaitForSeconds(time);
            for(int i = 0; i < seedCound; i++)
            {
                float angle = transform.eulerAngles.y + (transform.rotation.y + 5f * i) / 2;
                bulletCom.type = type;
                bulletCom.attack = attack;
                temp[i] = Instantiate(bullet, point.transform.position, Quaternion.Euler(0, angle, 0));
                temp[i].GetComponent<Rigidbody>().velocity = (point.transform.forward * 10f);
                
            }
            yield return new WaitForSeconds(0.01f);
            for (int i = 0; i < 6; i++)
            {
                temp[i].GetComponent<Rigidbody>().velocity = (temp[i].transform.forward * 10f);
                temp[i].transform.rotation=Quaternion.Euler(0, 0, 0);
            }

        }
    }


}
