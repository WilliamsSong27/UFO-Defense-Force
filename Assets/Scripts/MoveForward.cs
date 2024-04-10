using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 50.0f;

    // Update is called once per frame
    void Update()
    {
        //Move gameObject forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
