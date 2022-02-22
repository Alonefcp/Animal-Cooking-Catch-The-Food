using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{

    [SerializeField] float seconds = 5.0f;

    void Start()
    {
        GameObject.Destroy(gameObject, seconds);
    }
}
