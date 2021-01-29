using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughWall : MonoBehaviour
{
    List<GameObject> DeactivatedWalls;
    // Start is called before the first frame update
    void Start()
    {
        DeactivatedWalls = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> UpdatedDeactivatedWalls = DeactivatedWalls;
        GameObject player = GameObject.Find("Player");
        RaycastHit hit;
        Physics.Raycast(gameObject.transform.position, -(gameObject.transform.position - player.transform.position).normalized, out hit, Mathf.Infinity);
        if (hit.collider.gameObject.tag == "Wall")
        {
            hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
            DeactivatedWalls.Add(hit.collider.gameObject);
        }
        else {
            for (int i = 0; i < DeactivatedWalls.Count; i++)
            {
                DeactivatedWalls[i].GetComponent<MeshRenderer>().enabled = true;
                UpdatedDeactivatedWalls.Remove(DeactivatedWalls[i]);
            }
            DeactivatedWalls = UpdatedDeactivatedWalls;
        }

    }
}