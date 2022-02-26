using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;
    [SerializeField] private Joystick joystic;

    [SerializeField] private Transform rightLimit;
    [SerializeField] private Transform leftLimit;

    [SerializeField] private Transform splashEffect;
    [SerializeField] private OrderManager orderManager;

    Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {

#if UNITY_EDITOR
        float dir = GetKeyboardAxis();
#else
        float dir =  GetJoysticAxis();
#endif

        Vector3 movDirection = new Vector3(dir, 0.0f, 0.0f).normalized * speed;
        if(transform.position.x >= rightLimit.position.x)
        {
            transform.position = rightLimit.position;
        }
        else if(transform.position.x <= leftLimit.position.x)
        {
            transform.position = leftLimit.position;
        }
        transform.Translate(movDirection * Time.deltaTime,Space.Self);        
    }

    float GetJoysticAxis()
    {
        float dir;
        if (joystic.Horizontal > 0.2f)
        {
            dir = 1.0f;
        }
        else if (joystic.Horizontal < -0.2f)
        {
            dir = -1.0f;
        }
        else
        {
            dir = 0.0f;
        }

        return dir;
    }

    float GetKeyboardAxis()
    {
        return Input.GetAxisRaw("Horizontal");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Food")
        {
            Food food = other.gameObject.GetComponent<Food>();

            if (food!=null && orderManager.CurrentFoodOrder() == food.GetFoodType()) GameManager.instance.AddScore();
            else GameManager.instance.SubstractTries();

            Instantiate<Transform>(splashEffect, transform);
            GameObject.Destroy(other.gameObject);
        }
    }

    public void ResetPlayer()
    {
        transform.position = startPosition;
        //ParticleSystem ps = GetComponentInChildren<ParticleSystem>();

        //foreach (Transform t in transform)
        //{
        //    Debug.Log(t.gameObject.name);
        //}

        // if (ps!=null)
        //{
        //    GameObject.Destroy(ps.gameObject);
        //}
    }
}
