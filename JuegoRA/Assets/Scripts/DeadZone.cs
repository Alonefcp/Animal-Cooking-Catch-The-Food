using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Food")
        {
            audioSource.Play();
            GameManager.instance.SubstractTries();
        }
        GameObject.Destroy(other.gameObject);
    }
}
