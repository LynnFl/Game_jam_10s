using System.Collections;
using UnityEngine;

public class BlinkingObject : MonoBehaviour
{
    public float blinkDuration = 10f; // Total time the object will blink
    public float blinkSpeed = 1f; // Speed of the fade in and out

    private Material objectMaterial;
    private MeshRenderer meshRenderer;
    private Color startColor;
    private float startTime;
    private float delay;
    private bool isActive = false;
    void Start()
    {
        objectMaterial = GetComponent<Renderer>().material; // Get the material
        meshRenderer = GetComponent<MeshRenderer>();
        startColor = objectMaterial.color; // Store the original color
        meshRenderer.enabled = false;
        isActive = false;
        delay = 2f;
    }

    void Update()
    {
        // Calculate the fraction of the total duration that has passed
        if(delay > 0){
            delay -= Time.deltaTime;
            Debug.Log(delay);
        }
        else{
             if(isActive == false){
                meshRenderer.enabled = true;
                isActive = true;
                startTime = Time.time;
            }
            float lerpTime = Mathf.PingPong(Time.time - startTime, blinkSpeed) / blinkSpeed;
            float alpha = Mathf.Lerp(0f, 1f, lerpTime);
             Color newColor = new Color(startColor.r, startColor.g, startColor.b, alpha);
             objectMaterial.color = newColor;

        // Stop blinking after the duration has passed
            if (Time.time - startTime >= blinkDuration)
                {
                    objectMaterial.color = new Color(startColor.r, startColor.g, startColor.b, 0); // Reset to the original color
                    gameObject.SetActive(false); // Hide the object
                    this.enabled = false; // Disable this script
            
        }    
       
        }
        
    }
}
