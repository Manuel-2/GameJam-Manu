using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public static GameManager sharedInstance;


    [SerializeField]
    int trashPrice;


    private int money;
    private int trashCount;


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
        money = 0;
        trashCount = 50;
    }

    // Public methods ============

    public void sell(GameObject item)
    {
        if (item.CompareTag("Trash"))
        {
            Debug.Log("Vendiendo Basura individual..");
            money += trashPrice;
            Debug.Log("money : " + money);
        }
        else if (item.CompareTag("Bag"))
        {
            Bag bag = item.GetComponent<Bag>();
            money += bag.count * trashPrice;
            Debug.Log("BOLSAAAA..");
            Debug.Log("money : " + money);

        }
    }
}
