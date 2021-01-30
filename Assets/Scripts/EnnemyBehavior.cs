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
    public float dist_monster = 10f;
    PlayerMove player_script;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform.position;
        ag = GetComponent<NavMeshAgent>();
        player_script = player.GetComponent<PlayerMove>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!moving && !player_script.hide && Vector3.Distance(player.transform.position, transform.position) <= dist_monster)
        {
            ag.isStopped = false;
            ag.SetDestination(player.transform.position);
            target = player.transform.position;
            moving = true;
        }
        else if (player_script.hide) {
            ag.isStopped = true;
            moving = false;
        }
        else if ((target - transform.position).magnitude <= 1f) {
            ag.isStopped = false;
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
