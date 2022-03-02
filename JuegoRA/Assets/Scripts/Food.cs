using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] float fallSpeed = 0.1f;
    [SerializeField] float rotateSpeed = 50f;
    float rotateDir;

    private void Start()
    {
        rotateDir = Random.Range(-1f, 1f) <=0 ? -1.0f : 1.0f;
    }

    private void Update()
    {
        //Here we move and rotate the food
        if(GameManager.instance.isTracked() && !GameManager.instance.IsGameOver())
        {
                   
            transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed * rotateDir);
            transform.Translate(-Vector3.forward * Time.deltaTime * fallSpeed);
            
        }   
    }
}
