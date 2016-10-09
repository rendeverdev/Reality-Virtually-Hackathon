using UnityEngine;
using System.Collections;

public class GearHead : MonoBehaviour
{

    public static int NumberGearHeads = 0;

    public Vector3 m_pos;

	// Use this for initialization
	void Start ()
	{
	    NumberGearHeads++;
        Invoke("SetPosition", 0.5f);
	}

    // Update is called once per frame
    void SetPosition()
    {
	    transform.position = NetworkRoomController.Instance.m_GearProxyPositions[NumberGearHeads-1].position;
    }

}
