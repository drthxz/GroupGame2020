using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float disappear;
    public string type;
    public int attack;
    private Animator anim;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, disappear);
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    private void OnTriggerEnter(Collider other)
    {
        Health enemyHealth = other.GetComponent<Health>();
        if (enemyHealth != null && type!= enemyHealth.type)
        {
            anim.SetBool("Hit", true);
            rb.isKinematic = true;
            Destroy(gameObject,1.0f);
            enemyHealth.Damage= attack;
        }
        
    }

}
