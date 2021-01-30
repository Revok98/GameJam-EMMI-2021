using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FearBarManager : MonoBehaviour
{
    public Image Bar;
    public float fill;
    // Start is called before the first frame update
    void Start()
    {
        fill = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove player = GameObject.Find("Player").GetComponent<PlayerMove>();
        if (player.hide)
        {
            fill += Time.deltaTime * 0.1f;
            Bar.fillAmount = fill;
        }
        if (fill >= 1)
        {
            SceneManager.LoadScene("Eymeric");
        }
    }
}
