using UnityEngine;
using System.Collections;

public class GearHeadForGearRoom : PhotonView
{

    public static int NumberGearHeads = 0;

    public Vector3 m_pos;

	// Use this for initialization
	void Start ()
	{
        if (photonView.isMine)
            GameObject.Destroy(this);
	    NumberGearHeads++;
        Invoke("SetPosition", 2f);
	}

    // Update is called once per frame
    void SetPosition()
    {
        int gearId = 1;
        if (photonView.owner.customProperties["numGears"] != null)
        {
            gearId = (int)photonView.owner.customProperties["numGears"];
        }
        Debug.Log("gear id" + gearId);
        transform.position = NetworkRoomController.Instance.m_GearVRSpawns[gearId - 1].position;
    }

}
