using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]protected float _hp;
    public string type;
    private Animator anim;
    //private MeshRenderer mesh;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //mesh = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_hp == 0)
        {
            anim.SetBool("Dead", true);
            //mesh.enabled = false;
            Destroy(gameObject,0.5f);
        }
    }

    public virtual float Damage
    {
        get { return _hp; }
        set {
            _hp -= value;
            if (_hp < 0)
            {
                _hp = 0;
            }
        }
    }
}
