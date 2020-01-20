using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]protected float _hp;
    public string type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_hp == 0)
        {
            Destroy(gameObject);
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
