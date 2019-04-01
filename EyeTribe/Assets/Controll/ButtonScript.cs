using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool isExit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Execute()
    {
        if (isExit)
        {

            Application.Quit();
        }
        else
        {

            GameObject.Find("GameManager").GetComponent<GameManager>().NewGame();

        }

    }
}
