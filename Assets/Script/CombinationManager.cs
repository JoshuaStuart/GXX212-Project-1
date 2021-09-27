using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationManager : MonoBehaviour
{
    public static CombinationManager instance;

    public List<GameObject> storedCollisionObjects;

    private void Awake()
    {
        instance = this;
    }

    public void combineObjects()
    {
        GameObject obj1 = storedCollisionObjects[0];
        GameObject obj2 = storedCollisionObjects[1];


        obj1.GetComponent<SphereCollider>().enabled = false;
        obj2.GetComponent<SphereCollider>().enabled = false;

        GameObject newObj = Instantiate(GameManager.instance.bubble);
        newObj.transform.position = obj1.transform.position + (obj2.transform.position - obj1.transform.position) / 2;

        newObj.GetComponent<BallScript>().value = obj1.GetComponent<BallScript>().value + obj2.GetComponent<BallScript>().value;
        newObj.GetComponent<BallScript>().randomGen = false;
        newObj.GetComponent<BallScript>().setColour();

        storedCollisionObjects.Remove(obj1);
        storedCollisionObjects.Remove(obj2);
        Destroy(obj1);
        Destroy(obj2);
    }
}
