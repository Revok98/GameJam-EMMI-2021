using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyBehavior : MonoBehaviour
{
    NavMeshAgent ag;
    GameObject player;
    Vector3 target;
    private bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform.position;
        ag = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!moving) {
            ag.SetDestination(player.transform.position);
            moving = true;
        }
        if ((target - transform.position).magnitude <= 1f) {
            ag.SetDestination(player.transform.position);
            target = player.transform.position;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player") {
            Debug.Log("T'es mort");
        }
    }
}
