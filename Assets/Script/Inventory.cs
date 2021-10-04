using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<GameObject> slots;

    public List<GameObject> storedBubbles;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        foreach (GameObject bubble in storedBubbles)
        {
            bubble.transform.SetParent(slots[storedBubbles.IndexOf(bubble)].transform);
            bubble.transform.position = bubble.transform.parent.transform.position;
        }
    }

}
