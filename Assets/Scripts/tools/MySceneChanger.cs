using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneChanger : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // KEYBOARD
        //Load a scene by the name "SceneName" if you press the W key.
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Touche :"+KeyCode.X);
            SceneManager.LoadScene(sceneName);
        }

        // LEFT HAND
        //Load a scene by the name "SceneName" if you press the X button.
        if (OVRInput.GetUp(OVRInput.RawButton.X)) {
            SceneManager.LoadScene(sceneName);
        }



    }
}
