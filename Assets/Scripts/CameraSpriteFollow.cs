using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSpriteFollow : MonoBehaviour
{
    public float maxDistance = 30f;
    public Image image;

    void Update()
    {
        Vector3 spritePos = Camera.main.WorldToScreenPoint(this.transform.position);
        float distance = getDistanceFromCamera();
        float scale = 0f;
        if (distance <= maxDistance) scale = 1 - (distance / maxDistance);
        image.transform.position = spritePos;
        image.transform.localScale = new Vector3(scale,scale,1);
    }

    private float getDistanceFromCamera()
    {
        Vector3 v3Dist= this.transform.position - Camera.main.transform.position;
        return Vector3.Dot(v3Dist, Camera.main.transform.forward);
    }
}
