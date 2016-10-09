using UnityEngine;
using System.Collections;

public class BasketTarget : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        Room1TaskMananger.Instance.BasketCompleted();
    }
}
