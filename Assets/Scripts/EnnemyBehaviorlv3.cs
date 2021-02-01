using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class EnnemyBehaviorlv3 : MonoBehaviour
{
    NavMeshAgent ag;
    GameObject player;
    Vector3 target;
    private bool following = false;
    public float dist_monster = 10f;
    public float sightAngle = 45f;
    PlayerMove player_script;
    public List<Vector3> pattern = new List<Vector3>();
    int current_index = 0;
    private bool begin = false;
    private float dist_target;
    private Light lightSight;
    public Color stdColor;
    public Color alertColor;
    private bool returned = true;
    public MonsterAnimated monsterAnimation;


    void initLightElements()
    {
        GameObject lightChild = this.transform.Find("LightSight").gameObject;
        lightSight = lightChild.GetComponent<Light>();
        lightSight.spotAngle = sightAngle;
        lightSight.range = dist_monster;

    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform.position;
        ag = GetComponent<NavMeshAgent>();
        player_script = player.GetComponent<PlayerMove>();
        dist_target = transform.position.y;
        monsterAnimation.state = MonsterAnimated.states.STOP;

        initLightElements();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log((target - transform.position).magnitude);
        RaycastHit hit;
        float angle = Vector3.Angle(transform.forward,player.transform.position-transform.position);
        Physics.Raycast(gameObject.transform.position, -(gameObject.transform.position - player.transform.position).normalized, out hit, Mathf.Infinity);
        if (!following && !player_script.hide && Vector3.Distance(player.transform.position, transform.position) <= dist_monster && hit.collider.gameObject.tag == "Player" && angle <= sightAngle)
        {
            ag.isStopped = false;
            ag.SetDestination(player.transform.position);
            target = player.transform.position;
            following = true;
            monsterAnimation.state = MonsterAnimated.states.WALKING;
        }
        else if (following && (player_script.hide || (hit.collider.gameObject.tag != "Player" && angle >= sightAngle))) { //on arrête de follow
            ag.SetDestination(pattern[current_index]);
            target = pattern[current_index];
            following = false;
            returned = false;
        }
        else if (following && (target - transform.position).magnitude <= 1f) {
            ag.SetDestination(player.transform.position);
            target = player.transform.position;
        }
        else if (!returned && !following && (target - transform.position).magnitude <= dist_target+0.2f) {
            ag.isStopped = true;
            transform.rotation = Quaternion.Euler(0, -90, 0);
            returned = true;
        }

        if (following)
        {
            lightSight.color = alertColor;
        }
        else
        {
            lightSight.color = stdColor;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player") {
            SceneManager.LoadScene("GameOver");
        }
    }
}
