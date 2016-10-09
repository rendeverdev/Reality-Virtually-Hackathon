using UnityEngine;
using System.Collections;

public class Room1CheckProperties : MonoBehaviour
{

    public GameObject m_Wall;
    
	void Start () {
        if (!Room1PlatformManager.Instance.m_IsVive)
            InvokeRepeating("CheckProps", 0f, 0.25f);
    }

    public void CheckProps()
    {
        if (PhotonNetwork.room != null)
        {
            bool showClimbing = (bool)(PhotonNetwork.room.customProperties["ShowClimbingWall"] ?? false);
            if (showClimbing)
            {
                m_Wall.SetActive(true);
            }
        }
    }
}
