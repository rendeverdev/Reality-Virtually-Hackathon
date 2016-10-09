using UnityEngine;
using System.Collections;

public class Keyhole : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Key")
        {
            Debug.Log("Key inserted");
            Destroy(collider.gameObject);
            Room1TaskMananger.Instance.InsertKey();
        }
    }
}
