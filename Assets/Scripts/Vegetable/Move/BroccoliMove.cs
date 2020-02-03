using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroccoliMove : Move
{
    private new Transform[] broccooliImage=new Transform[4];
    
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

        for(int i=0;i<4;i++)
        {
            broccooliImage[i]=transform.GetChild(i);
        }
        
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
        
        for(int i=0;i<4;i++)
        {
            if(broccooliImage[i]!=null){
                broccooliImage[i].rotation=Quaternion.Euler (new Vector3(0, -180-transform.rotation.y, 0));//Quaternion.Euler(0, -180-transform.rotation.y, 0);
                //pointRotation[i].localRotation = Quaternion.Euler (0,-transform.rotation.eulerAngles.y,0);//transform.rotation;
            }
        }
    }
}
