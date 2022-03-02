using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    /// <summary>
    /// Every object that triggers with this gameobject it is destroyed
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //If a food triggers with this gameobject we substract lives
        if (other.gameObject.tag == "Food")
        {
            audioSource.Play();
            GameManager.instance.SubstractTries();
        }

        GameObject.Destroy(other.gameObject);
    }
}
