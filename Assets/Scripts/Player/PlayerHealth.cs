using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] private Slider health;
    private float maxHp;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = _hp;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        health.value = _hp / maxHp;
    }
    public override float Damage
    {
        get { return _hp; }
        set
        {
            _hp -= value;
            if (_hp < 0)
            {
                _hp = 0;
            }
        }
    }
}
