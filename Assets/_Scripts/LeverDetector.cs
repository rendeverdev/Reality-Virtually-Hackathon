using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeverDetector : MonoBehaviour
{
    public static List<LeverDetector> LeverDetectors = new List<LeverDetector>();

    public static event Action OnActivation;
    public static event Action OnDeactivation;

    public bool m_IsActivated = false;

    public int m_LeverId;

    public HingeJoint m_Hinge;

    public float m_ActivationAngle;

    void Start()
    {
        if (!Room1PlatformManager.Instance.m_IsVive)
            Destroy(this);
        LeverDetectors.Add(this);
    }

	// Update is called once per frame
	void Update ()
	{
	    if (!m_Hinge)
	        return;
	    if (!m_IsActivated && m_Hinge.angle > m_ActivationAngle)
	    {
	        m_IsActivated = true;
	        if (OnActivation != null)
	            OnActivation();
	    }
        else if (m_IsActivated && m_Hinge.angle < m_ActivationAngle)
	    {
	        m_IsActivated = false;
            if (OnDeactivation != null)
                OnDeactivation();
        }
    }
}
