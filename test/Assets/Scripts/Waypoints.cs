using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float waypointSize = 1f;
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        foreach(Transform child in transform)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(child.position, waypointSize);
        }
        Gizmos.color = Color.green;

        for(int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        
    }

    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
        if(currentWaypoint == null)
        {
            return transform.GetChild(0);
        }
        if(currentWaypoint.GetSiblingIndex() <= transform.childCount - 1)
        {
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }   
        else
        {
            return null;
        }
    }
}
