using UnityEngine;
using System.Collections;

public class LoadingDotsAnimation : MonoBehaviour
{
    public GameObject[] dots; // Assign your 3 dot GameObjects in the inspector
    public float animationSpeed = 0.5f; // Time in seconds for each dot's visibility toggle
    public float jumpHeight = 0.5f; // Height of the jump
    public float jumpDuration = 0.25f; // Duration of the jump

    public void beginLoading()
    {
        if(ScaleUpAnimation.beginLoadingDots == true)
        {
            StartCoroutine(AnimateDots());
        }
        
    }

    private IEnumerator AnimateDots()
    {
        int currentDot = 0;

        while (true) // Loop indefinitely
        {
            for (int i = 0; i < dots.Length; i++)
            {
                if (i == currentDot)
                {
                    // Start the jump animation for the current dot
                    StartCoroutine(JumpDot(dots[i]));
                }
            }

            // Move to the next dot
            currentDot = (currentDot + 1) % dots.Length;

            // Wait for the specified delay
            yield return new WaitForSeconds(animationSpeed);
        }
    }

    private IEnumerator JumpDot(GameObject dot)
    {
        // Save the starting position
        Vector3 startPos = dot.transform.position;
        Vector3 endPos = new Vector3(startPos.x, startPos.y + jumpHeight, startPos.z);

        // Tween up
        for (float t = 0; t < 1; t += Time.deltaTime / jumpDuration)
        {
            dot.transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        // Tween down
        for (float t = 0; t < 1; t += Time.deltaTime / jumpDuration)
        {
            dot.transform.position = Vector3.Lerp(endPos, startPos, t);
            yield return null;
        }

        // Ensure the dot is back at the starting position
        dot.transform.position = startPos;

        
    }
}
