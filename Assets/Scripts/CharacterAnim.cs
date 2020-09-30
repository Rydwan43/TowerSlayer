using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAnim : MonoBehaviour
{
    public bool CanJump;
    private Animator animator;
    private Rigidbody2D rb;
    int maxSkins = 2;
    private int character;
    private int gold;



    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        character = PlayerPrefs.GetInt("Selected_skin");
        gold = PlayerPrefs.GetInt("gold");
        try
        {
            animator.SetInteger("Color", character);
        }
        catch 
        {
            animator.SetInteger("Color", 0);
        }
        PlayerPrefs.SetInt("Skin", character);
    }

    // Update is called once per frame
    void Update()
    {
        gold = PlayerPrefs.GetInt("gold");

        if (rb.transform.position.y > -3.6f && CanJump)
        {
            animator.SetBool("Jumped", true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetInteger("Color", 0);
            PlayerPrefs.SetFloat("highscore", 0);
            PlayerPrefs.SetFloat("gold", 0);
            PlayerPrefs.SetInt("buy_0", 1);
            PlayerPrefs.SetInt("buy_1", 0);
            PlayerPrefs.SetInt("buy_2", 0);
            PlayerPrefs.SetInt("Skin", 0);
            PlayerPrefs.SetInt("Selected_skin", 0);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            int g = PlayerPrefs.GetInt("gold");
            g += 500;
            PlayerPrefs.SetInt("gold", g);
        }
    }


    public void PreviousSkin()
    {
        if (character > 0)
            character--;
        else
            character = maxSkins;
        animator.SetInteger("Color", character);
        animator.Play("Player_Idle", -1, 0f);
        PlayerPrefs.SetInt("Skin", character);
        Debug.Log(PlayerPrefs.GetInt("Skin"));

    }

    public void NextSkin()
    {
        if (character < maxSkins)
            character++;
        else
            character = 0;
        animator.SetInteger("Color", character);
        animator.Play("Player_Idle", -1, 0f);
        PlayerPrefs.SetInt("Skin", character);
        Debug.Log(PlayerPrefs.GetInt("Skin"));
    }

    public void SelectSkin()
    {
        int buyChecker = PlayerPrefs.GetInt("buy_" + character.ToString());
        if (buyChecker == 1)
        {
            PlayerPrefs.SetInt("Selected_skin", character);
            animator.SetInteger("Color", character);
        }
        else if (buyChecker == 0 && gold >= 500)
        {
            PlayerPrefs.SetInt("buy_" + character.ToString(), 1);
            gold -= 500;
            PlayerPrefs.SetInt("gold", gold);
            PlayerPrefs.SetInt("Selected_skin", character);
            animator.SetInteger("Color", character);
        }
    }
}
