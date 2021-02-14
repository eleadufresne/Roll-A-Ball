using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float height;

    // Update is called once per frame
    void Update()
    {
        //multiplying by deltaTime so it rotates smoothly 
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        
        transform.position = new Vector3(transform.position.x, height + Mathf.Sin(Time.time * speed)* range, transform.position.z) ;
    }
}
