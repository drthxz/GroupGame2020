using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float disappear;
    public string type;
    public int attack;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, disappear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Health enemyHealth = other.GetComponent<Health>();
        if (enemyHealth != null && type!= enemyHealth.type)
        {
            Destroy(gameObject);
            enemyHealth.Damage= attack;
        }
        
    }

}
