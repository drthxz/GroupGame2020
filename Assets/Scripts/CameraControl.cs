using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]private GameObject _player;
    public float y;
    public float z;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Character").gameObject;
        }
        distance = new Vector3(0, y, z);
        gameObject.transform.position = Vector3.Lerp(transform.position, _player.transform.position + distance, Time.deltaTime);
    }
}
