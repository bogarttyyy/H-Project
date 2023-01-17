using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CameraController : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;

    public GameObject playerObject;
    public GameObject playerCamObject;
    public GameObject worldCamObject;
    private Camera playerCam;
    private Camera worldCam;
    private MouseLook playerLook;
    public ARSession session;
    private bool hasReset = true;

    Transform currentView;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = playerCamObject.GetComponent<Camera>();
        worldCam = worldCamObject.GetComponent<Camera>();
        playerObject.SetActive(false);
        worldCamObject.SetActive(true);

        currentView = views[4];
    }

    void Update()
    {

    }

    void LateUpdate()
    {
        // Linear Interpolation Position
        MoveCamera(worldCam);
    }

    private void MoveCamera(Camera cam) {
        cam.transform.position = Vector3.Lerp(cam.transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, currentView.rotation, Time.deltaTime * transitionSpeed);

        IsOnTarget(cam);
    }

    private void IsOnTarget(Camera cam) {

        if (currentView == views[4])
        {
            playerObject.SetActive(false);
            worldCamObject.SetActive(true);
        } 
        else if((Vector3.Distance(cam.transform.position, currentView.position).ToString("0.00") == "0.00"))
        {
            playerObject.transform.position = cam.transform.position;
            playerObject.transform.rotation = cam.transform.rotation;
            playerCamObject.transform.position = cam.transform.position;
            playerCamObject.transform.rotation = cam.transform.rotation;

            if (!hasReset) {
                hasReset = true;
                session.Reset();
                playerCam.usePhysicalProperties = true;
                playerCam.gateFit = Camera.GateFitMode.Overscan;
            }

            playerObject.SetActive(true);
            worldCamObject.SetActive(false);
        } 
        else 
        {
            playerObject.SetActive(false);
            worldCamObject.SetActive(true);
        }
    }

    public void ChangeView(int view) {
        hasReset = false;
        currentView = views[view];
        Debug.Log(currentView);
    }
}
