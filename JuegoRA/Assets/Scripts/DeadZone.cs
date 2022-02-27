using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Food")
        {
            GameManager.instance.SubstractTries();
        }
        GameObject.Destroy(other.gameObject);
    }
}
