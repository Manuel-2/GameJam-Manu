using UnityEngine;

public class Store : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerController.sharedInstance.Drop();
        GameObject item = other.gameObject;
        GameManager.sharedInstance.sell(item);
        // TODO:: llamar animacion, particulas quisa?
        Destroy(item);
    }
}
