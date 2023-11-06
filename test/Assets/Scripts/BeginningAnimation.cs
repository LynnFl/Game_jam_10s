using UnityEngine;

public class BeginningAnimation : MonoBehaviour
{
    private float floatSpeed ;
    private float waveSpeed = 10.0f;
    private float waveHeight = 0.5f;

    private float waveTime = 0.0f;
    private float waveMaxTime = 1.0f;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float startTime;
    private bool reachedEndPosition = false;
    private float delayTime = 0.02f;
    
    public static bool isReadyForPlayer = false;

   


    void Start()
    {
        endPosition = transform.position;
        startPosition = new Vector3(endPosition.x, endPosition.y - 20.0f, endPosition.z);
        startTime = Time.time;
        waveMaxTime = Random.Range(0.1f, 0.8f);
        floatSpeed = Random.Range(18f, 23f);
        delayTime = Random.Range(0f, 0.1f);
        waveHeight = Random.Range(0.4f, 0.6f);
        isReadyForPlayer = false;
    }

    void Update()
    {
        delayTime = delayTime - Time.deltaTime;
        if(delayTime < 0){
            if (!reachedEndPosition){
                float distCovered = (Time.time - startTime) * floatSpeed;
                float journeyFraction = distCovered / Vector3.Distance(startPosition, endPosition);
                transform.position = Vector3.Lerp(startPosition, endPosition, journeyFraction);
                if (transform.position == endPosition){
                    reachedEndPosition = true;
                    startTime = Time.time; // Reset startTime for the wave movement
                }
            }
            else if(waveTime < waveMaxTime){
                float wave = Mathf.Sin((Time.time - startTime) * waveSpeed) * waveHeight;
                waveSpeed += 0.001f;
                transform.position = new Vector3(endPosition.x, endPosition.y + wave, endPosition.z);
                waveTime += Time.deltaTime;
            }
            else if(waveTime < waveMaxTime + 0.2f){
                transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime * floatSpeed);
                waveTime += Time.deltaTime;
            }
            else if(waveTime < waveMaxTime + 1f){
                waveTime += Time.deltaTime;
            }
            else{
                isReadyForPlayer = true;}
        }
    }
}
