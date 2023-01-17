using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwtich : MonoBehaviour
{
    public GameObject cameraOne;
    public GameObject cameraTwo;

    public Transform[] views;
    public float transitionSpeed;
    public Camera mainCam;
    Transform currentView;

    // Use this for initialization
    void Start()
    {
        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
        currentView = mainCam.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Change Camera Keyboard
        switchCamera();
    }

    //UI JoyStick Method
    public void cameraPositonM()
    {
        cameraChangeCounter();
    }

    //Change Camera Keyboard
    void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            cameraChangeCounter();
        }
    }

    //Camera Counter
    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    //Camera change Logic
    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set camera position 1
        if (camPosition == 0)
        {
            cameraOne.SetActive(true);
            cameraTwo.SetActive(false);
        }

        //Set camera position 2
        if (camPosition == 1)
        {
            cameraTwo.SetActive(true);
            cameraOne.SetActive(false);
        }

    }

    void LateUpdate()
    {
        // Linear Interpolation Position
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentView.rotation, Time.deltaTime * transitionSpeed);
    }

    public void ChangeToRoom() {
        currentView = views[0];
    }
    
    public void ChangeToGymEntrance() {
        currentView = views[1];
    }
    
    public void ChangeToGymInterior() {
        currentView = views[2];
    }
    
    public void ChangeToField() {
        currentView = views[3];
    }

    public void ChangeToWorld() {
        currentView = views[4];
    }
}
