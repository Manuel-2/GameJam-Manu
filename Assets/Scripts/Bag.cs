using UnityEngine;

public class Bag : Pickable
{
    public int capacity;
    public int count;

    void Start()
    {
        count = 0;
    }
}
