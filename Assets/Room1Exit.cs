using UnityEngine;
using System.Collections;
using VRTK;

public class Room1Exit : MonoBehaviour
{
    public VRTK_PlayerClimb playerClimb;

    public bool m_finishedLevel = false;

    void Start()
    {
        playerClimb.PlayerClimbEnded += PlayerClimbEnded;
    }

    void OnTriggerEnter(Collider collider)
    {
        m_finishedLevel = true;
        Room1TaskMananger.Instance.ExitToArchery();

        Debug.Log("At Exit!");
    }

    void PlayerClimbEnded(object sender, PlayerClimbEventArgs playerClimbEventArgs)
    {
        Debug.Log("Climb Ended");
        if (m_finishedLevel)
            Room1TaskMananger.Instance.ExitToArchery();
    }
}
