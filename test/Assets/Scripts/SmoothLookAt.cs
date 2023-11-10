using UnityEngine;

public class SmoothLookAt : MonoBehaviour
{
    [SerializeField]
    private Transform currentWaypoint;
    public float rotationSpeed = 2f; // Speed at which the object rotates towards the waypoint

    private void Update()
    {
        // Check if we have a waypoint to look at
        if (currentWaypoint != null)
        {
            Vector3 targetDirection = currentWaypoint.position - transform.position;
            // Calculate the rotation needed to point the forward vector at the target direction
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            // Smoothly rotate towards the target point over time
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // Public method to change the current waypoint
    public void SetCurrentWaypoint(Transform newWaypoint)
    {
        currentWaypoint = newWaypoint;
    }
}
