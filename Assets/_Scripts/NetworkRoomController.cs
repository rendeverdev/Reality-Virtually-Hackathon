using UnityEngine;
using System.Collections;
using System.Security;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class NetworkRoomController : Singleton<NetworkRoomController>
{
    public Transform[] m_GearVRSpawns;
    public Transform[] m_GearProxyPositions;
    public GameObject[] m_Switches;
    public GameObject m_Drawer;
    public GameObject m_Door;
    public GameObject m_Valve;
    public GameObject m_key;

    public Transform m_LeftHand;
    public Transform m_RightHand;
    public Transform m_Head;

	// Use this for initialization
	void Start () {
        ConnectToPhoton();
    }

    public void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
        PhotonNetwork.networkingPeer.TrafficStatsEnabled = true;
    }

    public void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 32 };
        PhotonNetwork.JoinOrCreateRoom("Hackathon", roomOptions, TypedLobby.Default);
    }

    public void OnJoinedRoom()
    {
        if (Room1PlatformManager.Instance.m_IsVive)
        {
            SpawnHMDProxy();
            SpawnRoom1Elements();
        }
        else
        {
            AddGearPlayer();
        }
    }

    void SpawnHMDProxy()
    {
        //GameObject leftProxyObj = PhotonNetwork.Instantiate("Whirligig", new Vector3(-1.15f, 1.25f, 0.134f), Quaternion.identity, 0);
        GameObject leftProxyObj = PhotonNetwork.Instantiate("NetworkProxy", new Vector3(50f, 50f, 50f), Quaternion.identity, 0);
        GameObject rightProxyObj = PhotonNetwork.Instantiate("NetworkProxy", new Vector3(50f, 50f, 50f), Quaternion.identity, 0);
        GameObject headProxyObj = PhotonNetwork.Instantiate("ViveHeadProxy", new Vector3(50f, 50f, 50f), Quaternion.identity, 0);
        NetworkProxy leftProxy = leftProxyObj.GetComponent<NetworkProxy>();
        NetworkProxy rightProxy = rightProxyObj.GetComponent<NetworkProxy>();
        NetworkProxy headProxy = headProxyObj.GetComponent<NetworkProxy>();

        headProxyObj.GetComponentInChildren<MeshRenderer>().enabled = false;
        leftProxyObj.GetComponentInChildren<MeshRenderer>().enabled = false;
        rightProxyObj.GetComponentInChildren<MeshRenderer>().enabled = false;

        leftProxy.m_TransformToCopy = m_LeftHand;
        rightProxy.m_TransformToCopy = m_RightHand;
        headProxy.m_TransformToCopy = m_Head;
        headProxy.GetComponent<Camera>().enabled = false;
    }

    public void SpawnRoom1Elements()
    {
        GameObject keyProxyObj = PhotonNetwork.Instantiate("KeyProxy", m_key.transform.position, m_key.transform.rotation, 0);
        NetworkProxy keyProxy = keyProxyObj.GetComponent<NetworkProxy>();
        keyProxy.m_TransformToCopy = m_key.transform;
        keyProxyObj.GetComponent<MeshRenderer>().enabled = false;

        GameObject doorProxyObj = PhotonNetwork.Instantiate("DoorProxy", m_Door.transform.position, m_Door.transform.rotation, 0);
        NetworkProxy doorProxy = doorProxyObj.GetComponent<NetworkProxy>();
        doorProxy.m_TransformToCopy = m_Door.transform;

        GameObject drawerProxyObj = PhotonNetwork.Instantiate("DrawerProxy", m_Drawer.transform.position, m_Drawer.transform.rotation, 0);
        NetworkProxy drawerProxy = drawerProxyObj.GetComponent<NetworkProxy>();
        drawerProxy.m_TransformToCopy = m_Drawer.transform;

        GameObject valveProxyObj = PhotonNetwork.Instantiate("KnobProxy", m_Valve.transform.position, m_Valve.transform.rotation, 0);
        NetworkProxy valveProxy = valveProxyObj.GetComponent<NetworkProxy>();
        valveProxy.m_TransformToCopy = m_Valve.transform;

        foreach (GameObject switchObj in m_Switches)
        {
            GameObject networkSwitchObj = PhotonNetwork.Instantiate("SwitchHandleProxy", switchObj.transform.position, switchObj.transform.rotation, 0);
            NetworkProxy networkSwitchProxy = networkSwitchObj.GetComponent<NetworkProxy>();
            networkSwitchProxy.m_TransformToCopy = switchObj.transform;
        }
    }

    public void AddGearPlayer()
    {
        if (PhotonNetwork.room != null)
        {
            int numGearPlayers = 0;
            if (PhotonNetwork.room.customProperties["gearNum"] != null)
            {
                numGearPlayers = (int)PhotonNetwork.room.customProperties["gearNum"];
            }
            numGearPlayers++;

            Hashtable newPlayerProps = new Hashtable();
            newPlayerProps.Add("numGears", numGearPlayers);
            PhotonNetwork.player.SetCustomProperties(newPlayerProps);

            Hashtable newRoomProperties = new Hashtable();
            newRoomProperties.Add("gearNum", numGearPlayers);
            PhotonNetwork.room.SetCustomProperties(newRoomProperties);

            m_Head.transform.position = m_GearVRSpawns[numGearPlayers - 1].position;

            Transform gearProxyPosition = m_GearProxyPositions[numGearPlayers - 1];
            GameObject headProxyObj = PhotonNetwork.Instantiate("GearHeadProxy", gearProxyPosition.position, Quaternion.identity, 0);
            NetworkProxy headProxy = headProxyObj.GetComponent<NetworkProxy>();
            headProxy.m_TransformToCopy = m_Head;

            GameObject headProxyObjForGearRoom = PhotonNetwork.Instantiate("GearHeadProxyForGearRoom", m_GearVRSpawns[numGearPlayers - 1].position, Quaternion.identity, 0);
            NetworkProxy headProxyForGearRoom = headProxyObjForGearRoom.GetComponent<NetworkProxy>();
            headProxyForGearRoom.m_TransformToCopy = m_Head;
        }
    }
}
