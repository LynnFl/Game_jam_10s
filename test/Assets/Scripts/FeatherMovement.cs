using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherMovement : MonoBehaviour
{
public Camera cameraToUse; 

void Update()
{
Ray ray = cameraToUse.ScreenPointToRay(Input.mousePosition);
Plane plane = new Plane(cameraToUse.transform.forward, cameraToUse.transform.position + cameraToUse.transform.forward * 0.3f);

if (plane.Raycast(ray, out float enter))
{
Vector3 hitPoint = ray.GetPoint(enter);
hitPoint.y = hitPoint.y - 0.3f; 
hitPoint.x = hitPoint.x + 0.1f;
transform.position = hitPoint;
}
}
}
        