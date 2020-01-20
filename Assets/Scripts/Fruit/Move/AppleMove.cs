using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleMove : Move
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        foreach (Health index in _character.GetComponentsInChildren<Health>())
        {
            if (index.type != gameObject.GetComponent<Health>().type)
            {
                enemyList.Add(index);
                //targetDistance.Add(1);
            }
        }
        targetDistance=new float[enemyList.Count];
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void FindEnemy(){
        base.FindEnemy();
    }

    protected override void MoveToTarget(int index){
        base.MoveToTarget(index);
    }
}
