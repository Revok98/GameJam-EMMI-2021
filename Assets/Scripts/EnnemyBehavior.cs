using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class EnnemyBehavior : MonoBehaviour
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
    private Material leftEye;
    private Material rightEye;
    public Color stdColor;
    public Color alertColor;


    void initLightElements()
    {
        GameObject lightChild = this.transform.Find("LightSight").gameObject;
        lightSight = lightChild.GetComponent<Light>();
        lightSight.spotAngle = sightAngle;
        lightSight.range = dist_monster;
        GameObject lEyeChild = this.transform.Find("LeftEye").gameObject;
        leftEye = lEyeChild.GetComponent<Renderer>().material;
        GameObject rEyeChild = this.transform.Find("RightEye").gameObject;
        rightEye = rEyeChild.GetComponent<Renderer>().material;

    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform.position;
        ag = GetComponent<NavMeshAgent>();
        player_script = player.GetComponent<PlayerMove>();
        dist_target = transform.position.y;

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
            ag.SetDestination(player.transform.position);
            target = player.transform.position;
            following = true;
        }
        else if (!begin) {
            target = pattern[current_index];
            ag.SetDestination(target);
            dist_target = transform.position.y;
            begin = true;
        }
        else if (following && (player_script.hide || (hit.collider.gameObject.tag != "Player" && angle >= sightAngle))) { //on arrête de follow
            ag.SetDestination(pattern[current_index]);
            target = pattern[current_index];
            following = false;
        }
        else if (following && (target - transform.position).magnitude <= 1f) {
            ag.SetDestination(player.transform.position);
            target = player.transform.position;
        }
        else if (!following && (target - transform.position).magnitude <= dist_target+0.2f) {
            current_index = (current_index + 1) % pattern.Count;
            ag.SetDestination(pattern[current_index]);
            target = pattern[current_index];
        }

        if (following)
        {
            lightSight.color = alertColor;
            leftEye.SetColor("_Color", alertColor);
            rightEye.SetColor("_Color", alertColor);
        }
        else
        {
            lightSight.color = stdColor;
            leftEye.SetColor("_Color", stdColor);
            rightEye.SetColor("_Color", stdColor);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player") {
            SceneManager.LoadScene("GameOver");
        }
    }
}
