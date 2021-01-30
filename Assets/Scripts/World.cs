using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class World : MonoBehaviour
{
    public GameObject agent;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
