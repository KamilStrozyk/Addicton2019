using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class CameraEfect : MonoBehaviour
{
 
    public RawImage fadeOutUIImage;
    public float fadeSpeed = 0.8f;
    private bool x=false;
    public void Show()
    {

    

            x = true;


     

    }
    public void Fade()
    {
        fadeOutUIImage.gameObject.SetActive(true);

        x = false;
           

    }

    void Start()
    {

        Show();


    }
    void Update()
    {
        if (x)
        {

            if (fadeOutUIImage.color.a > 0)
            {

                fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, fadeOutUIImage.color.a - fadeSpeed * Time.deltaTime);
            }
            else fadeOutUIImage.gameObject.SetActive(false);



        }

        else
        {

            fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, fadeOutUIImage.color.a + fadeSpeed * Time.deltaTime);


        }



    }

}
