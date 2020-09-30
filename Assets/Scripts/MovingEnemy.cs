using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{

    bool moveRight = false;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprite.transform.position.x > 1.71)
            moveRight = false;
        if (sprite.transform.position.x < -2.1)
            moveRight = true;
        if (moveRight)
            transform.position += new Vector3(0.4f, 0f, 0f) * Time.deltaTime * 5f;
        else
            transform.position -= new Vector3(0.4f, 0f, 0f) * Time.deltaTime * 5f;
    }
}
