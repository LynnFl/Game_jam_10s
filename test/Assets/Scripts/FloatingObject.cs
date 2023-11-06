using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloatingObject : MonoBehaviour
{
    private Rigidbody rb;
    public float buoyancyForce = 10.0f;
  


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        // 检查物体与水的相对位置
        float objectBottom = transform.position.y - (transform.localScale.y / 2);
        float objectTop = transform.position.y + (transform.localScale.y / 2);

        // 如果物体的底部低于水平面
        if (objectBottom < Water.waterLevel)
        {
            // 计算浮力
            float submergedPercentage = (Water.waterLevel - objectBottom) / transform.localScale.y;
            float force = Mathf.Clamp(buoyancyForce * submergedPercentage, 0, buoyancyForce);

            // 应用浮力
            rb.AddForce(Vector3.up * force);
        }
    }
}
