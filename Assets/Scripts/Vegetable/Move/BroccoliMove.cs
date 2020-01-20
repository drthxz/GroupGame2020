using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroccoliMove : Move
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        foreach (Health index in _character.GetComponentsInChildren<Health>())
        {
            if(index.type== "Fruit")
            {
                enemyList.Add(index);
            }
        }
        targetDistance=new float[enemyList.Count];
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(gameObject.transform.childCount==0){
            Destroy(gameObject);
        }
    }

    protected override void FindEnemy(){
        base.FindEnemy();
    }

    protected override void MoveToTarget(int index){
        base.MoveToTarget(index);
    }
}
