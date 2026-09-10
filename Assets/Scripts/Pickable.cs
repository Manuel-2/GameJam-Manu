using UnityEngine;

public class Pickable : MonoBehaviour
{
     void OnMouseDown()
    {
        PlayerController.sharedInstance.PickUp(this.transform);
    }

    void OnMouseOver()
    {
        // activar efecto fecback si esta en distancia de agarre (cerca del jugador)
    }
}
