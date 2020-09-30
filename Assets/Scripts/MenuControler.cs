using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuControler : MonoBehaviour
{
    public void Start()
    {
    }

    public void StoreButton()
    {
        SceneManager.LoadScene("Shop");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Level");
    }


}
