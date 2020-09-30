using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBuy : MonoBehaviour
{
    int gold;
    public GameObject GoldText;
    private Text goldText;

    public GameObject RequiredText;
    private Text requiredText;

    public GameObject SelectText;
    private Text selectText;

    private Animator animator;

    int character;
    int buy_checker;

    // Start is called before the first frame update
    void Start()
    {
        gold = PlayerPrefs.GetInt("gold");
        goldText = GoldText.GetComponent<Text>();
        selectText = SelectText.GetComponent<Text>();
        requiredText = RequiredText.GetComponent<Text>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gold = PlayerPrefs.GetInt("gold");
        goldText.text = "Coins: " + gold.ToString();
        character = PlayerPrefs.GetInt("Skin");
        buy_checker = PlayerPrefs.GetInt("buy_" + character.ToString());
        if (buy_checker == 0)
        {
            requiredText.text = "cost: 500 coins";
            selectText.text = "BUY";
        }
        else
        {
            requiredText.text = "";
            selectText.text = "SELECT";
        }

    }

}
