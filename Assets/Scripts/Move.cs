using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    protected GameObject _character;
    public List<Health> enemyList = new List<Health>();
    public float speed;
    //public List<float> targetDistance=new List<float>();
    public float[] targetDistance;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        _character = GameObject.Find("Character");
        
        targetDistance = new float[enemyList.Count];
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        FindEnemy();
    }

    public GameObject tempTarget;
    protected virtual void FindEnemy()
    {
        enemyList.RemoveAll(item => item == null);
        if (enemyList.Count == 0)
        {
            tempTarget = null;
        }
        for (int i = 0; i < enemyList.Count; i++)
        {
            targetDistance[i] = Vector3.Distance(gameObject.transform.position, enemyList[i].gameObject.transform.position);
            
            if (Mathf.Min(targetDistance[i]) == targetDistance[i])
            {
                tempTarget = enemyList[i].gameObject;
                MoveToTarget(i);
                
                if(enemyList.Count!=targetDistance.Length){
                    targetDistance = new float[enemyList.Count];

                }
            }
            
        }
        
    }

    protected virtual void MoveToTarget(int index)
    {
        transform.LookAt(tempTarget.transform);
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        if (Mathf.Min(targetDistance[index]) >= 5f)
        { 
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        
    }
}
