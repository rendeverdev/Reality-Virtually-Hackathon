using UnityEngine;
using System.Collections;
using System.Linq;

public class LeverTaskManager : MonoBehaviour
{

    public int[] m_RequiredLevers;

	// Use this for initialization
	void Start ()
	{
	    LeverDetector.OnActivation += ActiveLeversChanged;
	    LeverDetector.OnDeactivation += ActiveLeversChanged;
	}

    void ActiveLeversChanged()
    {
        int numCorrectLevers = 0;
        foreach (LeverDetector lever in LeverDetector.LeverDetectors)
        {
            if (lever.m_IsActivated && !m_RequiredLevers.Contains(lever.m_LeverId))
            {
                numCorrectLevers = -1;
                break;
            }
            if (lever.m_IsActivated && m_RequiredLevers.Contains(lever.m_LeverId))
                numCorrectLevers++;
        }
        if (numCorrectLevers == m_RequiredLevers.Length)
        {
            Room1TaskMananger.Instance.LeversCompleted();
            Debug.Log("got the right levers!");
        }
    }

}
