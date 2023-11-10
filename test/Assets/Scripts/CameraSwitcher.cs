using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera initialCamera; // Assign the initial Cinemachine Virtual Camera in the inspector
    public CinemachineVirtualCamera targetCamera; // Assign the target Cinemachine Virtual Camera in the inspector
    public float switchDelay = 1f; // Time in seconds to wait before switching cameras

    // This method will be called by the UI button to start the camera switch coroutine
    public void StartCameraSwitch()
    {
        StartCoroutine(SwitchCameraAfterDelay());
    }

    private IEnumerator SwitchCameraAfterDelay()
    {
        // Wait for the delay
        yield return new WaitForSeconds(switchDelay);

        // Switch the camera by setting the priority higher on the target camera
        initialCamera.Priority = 0;
        targetCamera.Priority = 1;
    }
}