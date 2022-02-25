using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private FoodType type;
    [SerializeField]float fallSpeed = 0.1f;
    [SerializeField]float rotateSpeed = 50f;

    float rotateDir;

    private void Start()
    {
        rotateDir = Random.Range(-1f, 1f) <=0 ? -1.0f : 1.0f;

    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime*rotateSpeed*rotateDir);
        transform.Translate(-Vector3.forward * Time.deltaTime * fallSpeed);
    }

    public FoodType GetFoodType()
    {
        return type;
    }
}
