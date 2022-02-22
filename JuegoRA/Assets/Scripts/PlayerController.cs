using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
   
    void Update()
    {
        float dir = Input.GetAxisRaw("Horizontal");

        Vector3 movDirection = new Vector3(dir, 0.0f, 0.0f).normalized*speed;

        transform.Translate(movDirection*Time.deltaTime);
    }
}
