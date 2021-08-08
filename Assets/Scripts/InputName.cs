using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onConfirmClicked()
    {
        Debug.Log("点击了一次");
        InputField inputField = FindObjectOfType<InputField>();
        string name = inputField.text;
        if (name != "")
        {
            Debug.Log(name);
            Global.name = name;
            SceneManager.LoadScene("Menu");
        }
    }
}
