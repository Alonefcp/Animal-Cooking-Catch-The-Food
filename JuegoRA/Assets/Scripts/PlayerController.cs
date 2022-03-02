using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;
    [SerializeField] private Joystick joystic;

    [SerializeField] private Transform rightLimit;
    [SerializeField] private Transform leftLimit;

    [SerializeField] private ParticleSystem splashEffect;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioClip clip2;

    Vector3 startPosition;
    float dir=0;

    private void Start()
    {
        //Initial position
        startPosition = transform.position;
    }

    void Update()
    {
        //Here we move the player
        if(!GameManager.instance.IsGameOver())
        {
#if UNITY_EDITOR
            dir = GetKeyboardAxis();
#else
        dir =  GetJoysticAxis();
#endif

            Vector3 movDirection = new Vector3(dir, 0.0f, 0.0f).normalized * speed;
            if (transform.position.x >= rightLimit.position.x)
            {
                transform.position = rightLimit.position;
            }
            else if (transform.position.x <= leftLimit.position.x)
            {
                transform.position = leftLimit.position;
            }
            transform.Translate(movDirection * Time.deltaTime, Space.Self);
        } 
    }

    /// <summary>
    /// Rretirns the joystick axis
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Returns the keyboard input axis
    /// </summary>
    /// <returns></returns>
    float GetKeyboardAxis()
    {
        return Input.GetAxisRaw("Horizontal");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Food")
        {
            audioSource.PlayOneShot(clip);
            GameManager.instance.AddScore();
        }
        else if(other.gameObject.tag=="RottenFood")
        {
            GameManager.instance.SubstractTries();
            audioSource2.PlayOneShot(clip2);
        }
        
        
        splashEffect.Play();          
        GameObject.Destroy(other.gameObject);
    }

    /// <summary>
    /// Sets te player position to its initial position and the joystick too
    /// </summary>
    public void ResetPlayer()
    {
        transform.position = startPosition;
        splashEffect.gameObject.SetActive(true);
        joystic.ResetJoystick(Vector2.zero);
    }

    /// <summary>
    /// Disables the player splash effect
    /// </summary>
    public void DisableSlaphEffect()
    {
        splashEffect.gameObject.SetActive(false);
    }
}
