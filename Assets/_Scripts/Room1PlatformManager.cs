using UnityEngine;
using System.Collections;

public class Room1PlatformManager : Singleton<Room1PlatformManager>
{

    public bool m_IsVive;
    public NetworkRoomController m_netController;

    public GameObject m_ViveHead;
    public GameObject m_GearHead;
    public GameObject m_ViveRig;

    public GameObject[] m_ObjectsToDeleteAndroid;

    void Awake()
    {
        if (!m_IsVive)
        {
            foreach (GameObject go in m_ObjectsToDeleteAndroid)
            {
                GameObject.Destroy(go);
            }
            GameObject.Destroy(m_ViveHead);
            m_netController.m_Head = m_GearHead.transform;
            RaycastHelper.Instance.m_RayTransform = m_netController.m_Head.transform;
        }
        else
        {
            m_ViveRig.SetActive(true);
            GameObject.Destroy(m_GearHead);
            m_netController.m_Head = m_ViveHead.transform;
        }
    }
}
