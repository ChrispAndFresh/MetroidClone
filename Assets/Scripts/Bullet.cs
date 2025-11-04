using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed; //Controls bullet speed
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1f, 0f, 0f) * speed * Time.deltaTime);
    }
}
