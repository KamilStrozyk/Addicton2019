using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectScript : MonoBehaviour
{
    public int Creativity = 0;
    public int Temperament = 0;
    public int Optymism = 0;
    public int Simplicity = 0;
    public int SocialSkills = 0;
    public int SelfControl = 0;
    public float AnimationLenght = 2;

    public string AnimationTrigger = "Papiesz";
    public float TimeWatched = 0;
    public float TimetoChoose = 0;
    private GameObject Progress;
    public Animator anim;

    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Progress = GameObject.Find("Progress");
        //   Progress.SetActive(true);
    }

    // Update is called once per frame
    void UpdatePoints()
    {
        GM.Creativity += Creativity;
        GM.Temperament += Temperament;
        GM.Optymism += Optymism;
        GM.Simplicity += Simplicity;
        GM.SocialSkills += SocialSkills;
        GM.SelfControl += SelfControl;
    }
    void UpdatePointsPartial()
    {
        GM.Creativity += Creativity * TimeWatched;
        GM.Temperament += Temperament * TimeWatched;
        GM.Optymism += Optymism * TimeWatched;
        GM.Simplicity += Simplicity * TimeWatched;
        GM.SocialSkills += SocialSkills * TimeWatched;
        GM.SelfControl += SelfControl * TimeWatched;


    }
    public void Solution()
    {
        UpdatePoints();

        StartCoroutine(WaitForAnimation());
        Debug.Log("dziala");


    }
    private IEnumerator WaitForAnimation()
    {
        anim.SetBool(AnimationTrigger, true);
        yield return new WaitForSeconds(AnimationLenght);
        Debug.Log("dziala2");
        GameObject.Find("Main Camera").GetComponent<CameraEfect>().Fade();
        yield return new WaitForSeconds(1);
        GM.ApplySolution(this);
    }

    void OnMouseOver()
    {
        WatchOnObject();

    }

    void OnMouseExit()
    {


        DisableWatchOnObject();
        UpdatePointsPartial();
        TimeWatched = 0;
    }

    void OnTriggerStay()
    {
        WatchOnObject();

    }

    void OnTriggerExit()
    {


        DisableWatchOnObject();
        UpdatePointsPartial();
        TimeWatched = 0;
    }

    void DisableWatchOnObject()
    {

        TimetoChoose = 0;


        Progress.SetActive(false);
    }

    void WatchOnObject()
    {

        TimeWatched += Time.deltaTime;
        TimetoChoose += Time.deltaTime;
        Progress.SetActive(true);
        Progress.GetComponent<ProgressBarCircle>().BarValue = TimetoChoose / GM.TimeToChoose * 100;
        Progress.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (TimetoChoose >= GM.TimeToChoose)
        {
            if (this.gameObject.GetComponent<Button>() != null)
            {

                GameObject.Find("Main Camera").GetComponent<CameraEfect>().Fade();
                this.gameObject.GetComponent<Button>().gameObject.SendMessage("Execute");

            }
            else
            {

                Progress.SetActive(false);
                Destroy(Progress);
                Solution();



            }

        }


    }

}
