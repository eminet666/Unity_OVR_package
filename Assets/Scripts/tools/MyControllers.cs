using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MyControllers : MonoBehaviour
{

    private TextMesh console;
    private bool dataEnable = true;
    private GameObject player;
    private Vector3 worldPos;
    private GameObject centerEye, leftHand, rightHand;
    private Vector3 headsetPos, leftHandPos, rightHandPos;
    private InputDevice head, left, right;

    // Start is called before the first frame update
    void Start()
    {
        console = GameObject.Find("MyConsole").GetComponent<TextMesh>();
        centerEye = GameObject.Find("CenterEyeAnchor");
        leftHand = GameObject.Find("LeftHandAnchor");
        rightHand = GameObject.Find("RightHandAnchor");
        player = GameObject.Find("OVRPlayerController_prefab");

        // List<InputDevice> devices = new List<InputDevice>();
        // InputDevices.GetDevices(devices);
        // foreach (var item in devices) { 
        //     console.text += item.name + item.characteristics +"\n";
        // }
        // head = devices[0];
        // left = devices[1];
        // right = devices[2];
    }

    // Update is called once per frame
    void Update()
    {
        console.text = "";
        console.color = Color.white;

        //PLAYER WORLD POSITION
        worldPos = player.transform.position;
        console.text += "world pos :"
             + " x = " + worldPos.x.ToString("N2") + " | "
             + " y = " + worldPos.y.ToString("N2") + " | "
             + " z = " + worldPos.z.ToString("N2");

        // PLAYER HEAD/LEFT/RIGHT POSITIONS
        headsetPos = centerEye.transform.position;
        leftHandPos = leftHand.transform.position;
        rightHandPos = rightHand.transform.position;
        console.text += "\nheadset :"
                     + " x = " + (headsetPos.x - worldPos.x).ToString("N2") + " | "
                     + " y = " + (headsetPos.y - worldPos.y).ToString("N2") + " | "
                     + " z = " + (headsetPos.z - worldPos.z).ToString("N2");
        console.text += "\nlefthand :"
                     + " x = " + (leftHandPos.x - worldPos.x).ToString("N2") + " | "
                     + " y = " + (leftHandPos.y - worldPos.y).ToString("N2") + " | "
                     + " z = " + (leftHandPos.z - worldPos.z).ToString("N2");
        console.text += "\nrighthand :"
                     + " x = " + (rightHandPos.x - worldPos.x).ToString("N2") + " | "
                     + " y = " + (rightHandPos.y - worldPos.y).ToString("N2") + " | "
                     + " z = " + (rightHandPos.z - worldPos.z).ToString("N2") + "\n\n";

        // INPUTS
        // source : https://developer.oculus.com/documentation/unity/unity-ovrinput/
        // RIGHT HAND
        // A button
        if (OVRInput.Get(OVRInput.Button.One)) console.text = "Right\nA button pressed";
        // B button
        if (OVRInput.Get(OVRInput.RawButton.B)) console.text = "Right\nB button pressed";
        // Index Trigger as a button if more than half way
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger)) 
            console.text = "Right Index Trigger pressed";
        // Hand Trigger as a button if more than half way        
        if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
            console.text = "Right Hand Trigger pressed";        
        // Thumbstick as a button
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstick)) 
            console.text = "Right Thumstick clicked";

        // LEFT HAND
        // X button
        if (OVRInput.GetUp(OVRInput.RawButton.X)) console.text = "Left\nX button released<";
        // Y button
        if (OVRInput.GetDown(OVRInput.Button.Four)) console.text = "Left\nY button pressed"; 
        // Start button _ toggle show/hide
        if (OVRInput.Get(OVRInput.Button.Start)) {
            if(dataEnable) { console.GetComponent<Renderer>().enabled = false; dataEnable = false;}
            else { console.GetComponent<Renderer>().enabled = true; dataEnable = true;}
        }
        // Index Trigger value
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.1f) {
            console.text = "Left Index Trigger = " + OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        }
        // Hand Trigger value
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.1f) {
            console.text = "Left Hand Trigger = " + OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        }
        // Thumbstick Up
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            console.text = "Left Thumstick Up";
        }
        // Thumbstick Down        
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {
            console.text = "Left Thumstick Down";
        }
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (input.x > 0.1f || input.x < -0.1f ) console.text = "Left Thumstick = "+input.x;

    }
}