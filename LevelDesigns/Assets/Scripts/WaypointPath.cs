using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{

    public List<Transform> m_Waypoints;
    public int m_Direction = 1;
    public StateController[] m_ControllersToAdd;

    void Awake()
    {
        m_Waypoints = new List<Transform>(); 
        m_Waypoints.AddRange(gameObject.GetComponentsInChildren<Transform>());
        m_Waypoints.Remove(gameObject.transform);

        if (m_ControllersToAdd.Length > 0)
        {
            for (int i = 0; i < m_ControllersToAdd.Length; i++)
            {
                m_ControllersToAdd[i].SetupAI(true, m_Waypoints);
            }
        }
    }

}
