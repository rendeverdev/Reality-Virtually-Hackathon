using UnityEngine;
using System.Collections;

public class RaycastHelper : Singleton<RaycastHelper>
{
    public Transform m_RayTransform;

    public bool m_Debug;

    void Update()
    {
        if (m_Debug)
            Debug.DrawRay(m_RayTransform.position, m_RayTransform.forward);
    }

    // Update is called once per frame
    public Ray GetRay ()
	{
	    return new Ray(m_RayTransform.position, m_RayTransform.forward);

	}
}
