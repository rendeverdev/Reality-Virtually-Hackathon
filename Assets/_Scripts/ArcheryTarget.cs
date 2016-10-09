using UnityEngine;
using System.Collections;

public class ArcheryTarget : MonoBehaviour
{

    public static int NumTargetsHit = 0;

    public bool m_IsTarget;
    public bool m_ThisTargetHit = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Contains("Arrow") && m_IsTarget)
        {
            Debug.Log("arrow hit " + gameObject.name);
            if (!m_ThisTargetHit)
            {
                m_ThisTargetHit = true;
                NumTargetsHit++;
                if (NumTargetsHit == 4)
                {
                    Room1TaskMananger.Instance.AllComplete();
                }
            }
        }
    }
}
