using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    private int speed=20;
    private int margin = 10;

    public int Speed = 20;
    public int Margin = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVars();
       
        if (Input.mousePosition.x >= Screen.width - margin)
        {

            transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));

        }
        else if (Input.mousePosition.x<=margin)
        {

            transform.Rotate(new Vector3(0, -speed * Time.deltaTime, 0));

        }
   

    }

    void UpdateVars()
    {


        speed = Speed;
        margin = Margin;
    }
}
