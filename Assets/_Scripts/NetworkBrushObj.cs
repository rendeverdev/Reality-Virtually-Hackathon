using UnityEngine;
using System.Collections;

public class NetworkBrushObj : PhotonView {
    void Awake()
    {
        Color brushColor = Color.blue;
        if (photonView.ownerId == 0)
            brushColor = Color.green;
        else if (photonView.ownerId == 1)
            brushColor = Color.red;
        else if (photonView.ownerId == 2)
            brushColor = Color.black;
        else if (photonView.ownerId == 3)
            brushColor = Color.yellow;
        else if (photonView.ownerId == 4)
            brushColor = Color.magenta;
        else if (photonView.ownerId == 5)
            brushColor = Color.cyan;

        transform.parent=NetworkBrushController.Instance.m_NetworkBrushContainer; //Add the brush to our container to be wiped later
        //Color brushColor = NetworkBrushController.Instance.m_BrushColor;
        brushColor.a = NetworkBrushController.Instance.m_BrushSize * 2.0f; // Brushes have alpha to have a merging effect when painted over.

        GetComponent<SpriteRenderer>().color = brushColor;
    }
}
