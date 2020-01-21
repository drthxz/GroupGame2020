using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMove : MonoBehaviour
{
    float posY;
    float posX;
    // Start is called before the first frame update
    void Start()
    {
        posY = transform.position.y;
        posX = transform.position.x;
        xOffset = Random.Range(10f, 15);
        yOffset = Random.Range(5f, 10);
        xSpeed = Random.Range(10, 15);
        ySpeed = Random.Range(6, 10);
    }
    float xOffset;
    [SerializeField]
    float yOffset;
    float xSpeed;
    [SerializeField]
    float ySpeed;

    // Update is called once per frame
    void Update()
    {

       transform.position = new Vector3(transform.position.x, posY + Mathf.PingPong(Time.time * ySpeed, yOffset), transform.position.z);

    }


}
