using UnityEngine;
using System.Collections.Generic;

public class OnRockEnter : MonoBehaviour
{
    // Tags to check for
    public string tag1 = "Cat";
    public string tag2 = "Obstacles";
    public GameObject catMeow;

    public CatMoving cat;

    // Lists to keep track of objects with the tags that are currently in the trigger
    private HashSet<GameObject> objectsWithTag1 = new HashSet<GameObject>();
    private HashSet<GameObject> objectsWithTag2 = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has tag1 and add it to the list
        if (other.CompareTag(tag1))
        {
            objectsWithTag1.Add(other.gameObject);
        }
        
        // Check if the object has tag2 and add it to the list
        if (other.CompareTag(tag2))
        {
            objectsWithTag2.Add(other.gameObject);
        }

        CheckForBothTags();
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove the object from the appropriate list when it exits the trigger
        if (other.CompareTag(tag1))
        {
            objectsWithTag1.Remove(other.gameObject);
        }
        
        if (other.CompareTag(tag2))
        {
            objectsWithTag2.Remove(other.gameObject);
        }
    }

    // Method to check if there are objects with both tags in the trigger
    private void CheckForBothTags()
    {
        if (objectsWithTag1.Count > 0 && objectsWithTag2.Count > 0)
        {
            cat.SetCatSit();
            cat.isBlockedByRock = true;
            catMeow.SetActive(true);
            Debug.Log("Cat is blocked by rock");

            // Perform additional actions here if needed
        }
        else cat.isBlockedByRock = false;
    }
}
