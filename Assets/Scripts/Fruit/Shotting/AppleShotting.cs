using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleShotting : Shotting
{
    [SerializeField] private int cound;
    private bool speedup;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        StartCoroutine(Shotting());
        
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
                StopAllCoroutines();
                StartCoroutine(Shotting(0.5f));
            }
        }else{
            enemy=gameObject.GetComponent<Move>().tempTarget;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var temp = other.gameObject.GetComponent<Health>();
        if (temp && temp.type == "Vegetable")
        {
            enemy = other.gameObject;
            _shotting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var temp = other.gameObject.GetComponent<Health>();
        if (temp && temp.type == "Vegetable")
        {
            _shotting = false;
            speedup = false;
        }
    }

    IEnumerator Shotting(float speed=1.5f)
    {
        GameObject []temp=new GameObject[cound];
        while (true)
        {
            yield return new WaitForSeconds(speed);
            for(int i = 0; i < cound; i++)
            {
                float angle = transform.eulerAngles.y + (transform.rotation.y + 5f * i) / 2;
                if (i < 4)
                {
                   // angle = transform.eulerAngles.y + (transform.rotation.y - 5f * i) / 2;
                }
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
