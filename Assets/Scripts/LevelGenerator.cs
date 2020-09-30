using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelPart_1;
    [SerializeField] private Transform levelPart_2;
    [SerializeField] private Transform levelPart_3;
    [SerializeField] private Transform levelPart_4;

    public GameObject player;

    private Vector2 positionChecker;
    private int iterator = 2;

    // Start is called before the first frame update
    private void Awake()
    {
        //2,866618 9,24
        positionChecker = player.transform.position + new Vector3(0f,4f,0f);



        Instantiate(levelPart_1, new Vector3(-0.3374026f, Mathf.Abs(-3.462879F) *2 - 1.7314395f), Quaternion.identity);

        //for (int i = 2; i < 20; i+=2)
        //{
        //    Instantiate(levelPart_2, new Vector3(-0.3374026f, (i * Mathf.Abs(-3.462879F) * 2)), Quaternion.identity);
        //    Instantiate(levelPart_1, new Vector3(-0.3374026f, ((i+1) * Mathf.Abs(-3.462879F) * 2)), Quaternion.identity);
        //}
        
    }

    private void Update()
    {
        if (player.transform.position.y > positionChecker.y + 7f)
        {
            randomlyGenerate(iterator);
            randomlyGenerate(iterator + 1);
            iterator += 2;
            positionChecker.y = player.transform.position.y + +3.462879F;
            
            
        }
    }

    private void randomlyGenerate(int iterator)
    {
        int randomizer = Random.Range(0, 40);
        if (randomizer<=10)
            Instantiate(levelPart_1, new Vector3(-0.3374026f, (iterator * Mathf.Abs(-3.462879F) * 2)), Quaternion.identity);
        if (randomizer>10&&randomizer<=20)
            Instantiate(levelPart_2, new Vector3(-0.3374026f, (iterator * Mathf.Abs(-3.462879F) * 2)), Quaternion.identity);
        if (randomizer>20&&randomizer<=30)
            Instantiate(levelPart_3, new Vector3(-0.3374026f, (iterator * Mathf.Abs(-3.462879F) * 2)), Quaternion.identity);
        if (randomizer>30&&randomizer<=40)
            Instantiate(levelPart_4, new Vector3(-0.3374026f, (iterator * Mathf.Abs(-3.462879F) * 2)), Quaternion.identity);
    }
    
}
