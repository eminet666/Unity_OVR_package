using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyText : MonoBehaviour
{
    private TextMesh texte;


    // Start is called before the first frame update
    void Start()
    {
        texte = GameObject.Find("MyConsole").GetComponent<TextMesh>();
        texte.text = "Console Ready";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
