using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{

    [SerializeField] float seconds = 5.0f;

    void Start()
    {
        //Destroys the object after an amount of time
        GameObject.Destroy(gameObject, seconds);
    }
}
