using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;
    private Vector3 delta;
    // Start is called before the first frame update
    void Start()
    {
        delta = transform.position - target.transform.position;
    }
      

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + delta;
    }
}
