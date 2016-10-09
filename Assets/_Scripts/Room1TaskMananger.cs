using UnityEngine;
using System.Collections;
using VRTK;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Room1TaskMananger : Singleton<Room1TaskMananger>
{
    public AudioSource m_AudioSourceLevers;

    public GameObject m_Player;
    public GameObject m_ArcherySpawn;

    public GameObject m_Handholds;
    public VRTK_InteractableObject m_MainDoor;
    public VRTK_InteractableObject m_Drawer;

    public bool m_LeversCompleted;
    public bool m_ValveCompleted;
    public bool m_KeyInserted;
    public bool m_BasketComleted;

    public GameObject m_ClimbingWall;

    public void LeversCompleted()
    {
        m_LeversCompleted = true;
        m_Drawer.enabled = true;
        m_AudioSourceLevers.Play();
    }

    public void BasketCompleted()
    {
        m_Handholds.SetActive(true);
    }

    public void InsertKey()
    {
        m_MainDoor.enabled = true;
    }

    public void UseValve()
    {
        m_ClimbingWall.SetActive(true);
        Hashtable newRoomProperties = new Hashtable();
        newRoomProperties.Add("ShowClimbingWall", true);
        PhotonNetwork.room.SetCustomProperties(newRoomProperties);
    }

    [ContextMenu("ExitToArchery")]
    public void ExitToArchery()
    {
        m_Player.transform.position = m_ArcherySpawn.transform.position;
    }

    public void AllComplete()
    {
        m_AudioSourceLevers.Play();
        Debug.Log("SUCCESS!");
    }
}
