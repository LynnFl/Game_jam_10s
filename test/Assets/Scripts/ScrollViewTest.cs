using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollViewTest : MonoBehaviour, IPointerClickHandler
{
    public ScrollRect scrollRect; // Assign your ScrollRect in the inspector
    public GameObject[] imageContainers; // Assign your 3 image containers in the inspector

    public AudioClip audioClip;
    private AudioSource audioSource;

    private int currentImageIndex = 0;

    void Start()
    {
        // Initialize with the first image
        if (imageContainers.Length == 3)
        {
            UpdateImage();
        }
        else
        {
            Debug.LogError("You need to assign exactly 3 image containers to the ScrollViewTest script.");
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = false;
        audioSource.volume = 100f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // When the viewport is clicked, change the image
        currentImageIndex = (currentImageIndex + 1) % imageContainers.Length;
        audioSource.Play();
        UpdateImage();
    }

    public int GetCurrentImageIndex()
    {
        return currentImageIndex;
    }

    private void UpdateImage()
    {
        // Hide all images
        foreach (GameObject container in imageContainers)
        {
            container.SetActive(false);
        }

        // Show only the current image
        imageContainers[currentImageIndex].SetActive(true);
    }
}
