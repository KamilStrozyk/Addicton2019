using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Points
    public float Creativity=0;
    public float Temperament = 0;
    public float Optymism = 0;
    public float Simplicity = 0;
    public float SocialSkills = 0;
    public float SelfControl = 0;

    public String[] Scenes = {"Level1", "Level2", "Level3", "Level4", "Level5", "End"};
    public float[] TimeElapsed = {0f, 0f, 0f, 0f, 0f, 0f};
    private int count = 0;
    public GameObject ProgressBar;
    public float TimeToChoose = 3f;
    //TODO: reszta punktów
    void Awake()
    {
       

        DontDestroyOnLoad(this);
        ProgressBar = GameObject.Find("Progress");

    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Main Camera").GetComponent<CameraEfect>().Show();
    }

    // Update is called once per frame
    void Update()
    {
        TimeElapsed[count] += Time.deltaTime;
    }

    public void NewGame()
    {
        //Zeruj wszystko
        Creativity = 0;
        Temperament = 0;
        Optymism = 0;
        Simplicity = 0;
        SocialSkills = 0;
        SelfControl = 0;

        SceneManager.LoadScene(Scenes[count++]);
    }

    public void DisableProgress()
    {


        ProgressBar = null;
    }
    public void ApplySolution(ObjectScript OS)
    {
        GameObject.Find("Main Camera").GetComponent<CameraEfect>().Fade();
        SceneManager.LoadScene(Scenes[count++]);

    }

    public void Quit()
    {

        Application.Quit();


    }
}
