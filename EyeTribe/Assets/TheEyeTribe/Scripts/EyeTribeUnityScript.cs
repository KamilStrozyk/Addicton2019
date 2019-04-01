using UnityEngine;
using System.Collections;
using System.Threading;
using TETCSharpClient;
using TETCSharpClient.Data;
using UnityEngine.Experimental.PlayerLoop;
using System;
using System.Numerics;
using UnityEditor;
using UnityEngine.Assertions.Comparers;
using Vector3 = UnityEngine.Vector3;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using System.Drawing;
using Vector2 = UnityEngine.Vector2;

public class EyeTribeUnityScript : MonoBehaviour, IGazeListener
{
    private Camera _Camera;
    private GameObject _GazeIndicator;
    private GameObject _Player;
    private GameObject[] _GameObject;
    private bool _ShowGazeIndicator = true;

    public int speed = 20;
    public int margin = 10;

    private int Speed = 20;
    private int Margin = 10;
    private GameObject Progress;

    /*
     * Trzeba dodać tablicę, która odczytuje wszystkie GameObjecty.
     * N.V.M.
     */
    void Start()
    {
        Progress = GameObject.Find("Progress");

        //Screen.lockCursor = true;
        _Camera = GetComponentInChildren<Camera>();
        _GazeIndicator = GameObject.FindGameObjectWithTag("gazeIndicator");
        _Player = GameObject.FindWithTag("Player");

        _GameObject = GameObject.FindGameObjectsWithTag("GameObject");

        //activate C# TET client, default port
        GazeManager.Instance.Activate
        (
            GazeManager.ApiVersion.VERSION_1_0,
            GazeManager.ClientMode.Push
        );

        //register for gaze updates
        GazeManager.Instance.AddGazeListener(this);
        Cursor.visible = false;
    }

    public void OnGazeUpdate(GazeData gazeData)
    {
        //Add frame to GazeData cache handler
        GazeDataValidator.Instance.Update(gazeData);
    }

    void Update()
    {
        UpdateMovement();
        //    CheckLooking();

        Point2D gazeCoords = GazeDataValidator.Instance.GetLastValidSmoothedGazeCoordinates();

        Vector3 planeCoord = Vector3.zero;
        if (null != gazeCoords)
        {
            // Map gaze indicator
            Point2D gp = UnityGazeUtils.GetGazeCoordsToUnityWindowCoords(gazeCoords);

            Vector3 screenPoint = new Vector3((float) gp.X, (float) gp.Y, _Camera.nearClipPlane + .1f);

            Progress.transform.position = new Vector2((float) gp.X, (float)gp.Y);

  //if((gp.Y>=Screen.height/2&&_GazeIndicator.transform.rotation.y<40)|| (gp.Y  <= Screen.height / 2 && _GazeIndicator.transform.rotation.y > -40))         _GazeIndicator.transform.Rotate(new Vector3(4*Time.deltaTime,0,0));

            // Here looking updates
            //   Input.mousePosition.Set(screenPoint.x, screenPoint.y, screenPoint.z);
            UpdateRotate(screenPoint.x);

            planeCoord = _Camera.ScreenToWorldPoint(screenPoint);
            _GazeIndicator.transform.position = planeCoord;
        }

        if (_ShowGazeIndicator && !_GazeIndicator.activeSelf)
            _GazeIndicator.SetActive(true);
        else if (!_ShowGazeIndicator && _GazeIndicator.activeSelf)
            _GazeIndicator.SetActive(false);
    }

    void UpdateMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 20 * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(10 * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -20 * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-10 * Time.deltaTime, 0, 0));
        }
    }

    void UpdateRotate(float gX)
    {
        speed = Speed;
        margin = Margin;

        if ( gX > Screen.width - margin)
        {
            transform.Rotate(new Vector3(0, 20 * Time.deltaTime, 0));
            Debug.Log("Rotate X: 1.");
        }
        else if (gX < margin)
        {
            transform.Rotate(new Vector3(0, -20 * Time.deltaTime, 0));
            Debug.Log("Rotate X: -1.");
        }
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.F1))
        {
            _ShowGazeIndicator = !_ShowGazeIndicator;
        }

        if (Input.GetKey(KeyCode.F1))
        {
            _ShowGazeIndicator = !_ShowGazeIndicator;
        }
    }

    void OnApplicationQuit()
    {
        GazeManager.Instance.RemoveGazeListener(this);
        GazeManager.Instance.Deactivate();
    }

    public void GazeIndicatorButtonPress()
    {
        _ShowGazeIndicator = !_ShowGazeIndicator;
    }



}

   