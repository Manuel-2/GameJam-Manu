using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController sharedInstance;

    private Vector3 direction;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody body;


    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this);
        }

        Application.targetFrameRate = 60;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        body.AddForce(direction * speed * Time.deltaTime);
    }
}
