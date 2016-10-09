using UnityEngine;
using System.Collections;

public class NetworkProxy : MonoBehaviour
{
    public Transform m_TransformToCopy;
    public bool m_CopyRotation;
    public bool m_CopyPosition;
    public bool m_CopyScale;

    void Update()
    {
        if (m_TransformToCopy)
        {
            if (m_CopyPosition)
                transform.position = m_TransformToCopy.position;
            if (m_CopyRotation)
                transform.rotation = m_TransformToCopy.rotation;
                transform.localScale = m_TransformToCopy.lossyScale;
        }
    }
}
