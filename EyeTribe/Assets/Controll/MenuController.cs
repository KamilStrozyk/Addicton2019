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

public class MenuController : MonoBehaviour, IGazeListener
{
    private Camera _Camera;
    private GameObject _GazeIndicator;
    private GameObject _Player;
    private GameObject[] _GameObject;
    private bool _ShowGazeIndicator = true;

    private GameObject Progress;
    
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        Point2D gazeCoords = GazeDataValidator.Instance.GetLastValidSmoothedGazeCoordinates();

        Vector3 planeCoord = Vector3.zero;
        if (null != gazeCoords)
        {
            // Map gaze indicator
            Point2D gp = UnityGazeUtils.GetGazeCoordsToUnityWindowCoords(gazeCoords);

            Vector3 screenPoint = new Vector3((float)gp.X, (float)gp.Y, _Camera.nearClipPlane + .1f);

            Progress.transform.position = new Vector2((float)gp.X, (float)gp.Y);

            // Here looking updates
            /* Sprawdzanie bounds */



            planeCoord = _Camera.ScreenToWorldPoint(screenPoint);
            _GazeIndicator.transform.position = planeCoord;
        }

        if (_ShowGazeIndicator && !_GazeIndicator.activeSelf)
            _GazeIndicator.SetActive(true);
        else if (!_ShowGazeIndicator && _GazeIndicator.activeSelf)
            _GazeIndicator.SetActive(false);
    }

    void CheckBounds()
    {

    }
}
