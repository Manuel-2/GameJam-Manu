using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public static PlayerController sharedInstance;

    [Header("Movement")]
    private Vector3 direction;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody body;

    [Header("Inventory")]
    [SerializeField]
    private float reach;
    [SerializeField]
    private Transform hand;
    private Transform carryObject;



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

        carryObject = null;
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

        if (Input.GetMouseButtonDown(1))
        {
            Drop();
        }
    }


    // publicos


    public void PickUp(Transform item)
    {
        float distance = (item.position - this.transform.position).magnitude;
        if (distance > reach) return;

        if (carryObject != null && carryObject.CompareTag("Bag"))
        {
            Debug.Log("Guardando en bolsa");
            Bag bag = carryObject.GetComponent<Bag>();
            if (bag.count < bag.capacity)
            {
                bag.count++;
                Destroy(item.gameObject);
            }
            else
            {
                Debug.Log("llena");
            }
        }

        if (carryObject != null) return;

        carryObject = item;
        item.SetParent(hand);
        item.localPosition = Vector3.zero;
    }

    public void Drop()
    {
        if (carryObject == null) return;
        carryObject.SetParent(null);
        carryObject.position = hand.position;
        carryObject = null;
    }
}
