using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class World : MonoBehaviour
{
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
        NavMeshAgent BonhommeAgent = NavMeshAgent.Instantiate(agent, new Vector3(9,0,9), Quaternion.identity);
        BonhommeAgent.SetDestination(GameObject.Find("Player").transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
