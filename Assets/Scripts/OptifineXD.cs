using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptifineXD : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        Application.targetFrameRate = 60;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player.transform.position.y >
            this.gameObject.transform.position.y + 20f)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
