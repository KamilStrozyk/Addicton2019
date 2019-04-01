using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIChart : MonoBehaviour
{
    private GameManager GM;

    public ProgressBar[] Pb;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();








        




    }

    // Update is called once per frame
    void Update()
    {

        if (Pb[0].BarValue < GM.Creativity / 10 * 100) Pb[0].BarValue += 60 * Time.deltaTime;
        if (Pb[1].BarValue < GM.Temperament / 10 * 100) Pb[1].BarValue += 60 * Time.deltaTime;
        if (Pb[2].BarValue < GM.Optymism / 10 * 100) Pb[2].BarValue += 60 * Time.deltaTime;
        if (Pb[3].BarValue < GM.Simplicity / 10 * 100) Pb[3].BarValue += 60 * Time.deltaTime;
        if (Pb[4].BarValue < GM.SocialSkills / 10 * 100) Pb[4].BarValue += 60 * Time.deltaTime;
        if (Pb[5].BarValue < GM.SelfControl / 10 * 100) Pb[5].BarValue += 60 * Time.deltaTime;










    }


}
