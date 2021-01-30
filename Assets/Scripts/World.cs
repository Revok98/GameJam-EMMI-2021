using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class World : MonoBehaviour
{
    public GameObject agent;
    public GameObject terrain;

    // Start is called before the first frame update
    void Start()
    {
        terrain.GetComponent<NavMeshSurface>().BuildNavMesh();
        Instantiate(agent, this.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
