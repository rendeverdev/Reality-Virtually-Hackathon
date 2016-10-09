using UnityEngine;
using System.Collections;
using VRTK;

public class VRValve : VRTK_InteractableObject {

    public override void Grabbed(GameObject grabbingObject)
    {
        base.Grabbed(grabbingObject);
        Room1TaskMananger.Instance.UseValve();
    }

}
