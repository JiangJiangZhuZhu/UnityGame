using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundControl : MonoBehaviour
{
    // Start is called before the first frame update

    public float Speed = 10f;
    private GameObject Back;
    private GameObject Continue;
    private bool isSuspend;
    private void Awake()
    {
        Back = GameObject.Find("Back");
        Continue = GameObject.Find("Continue");
        Back.SetActive(false);
        Continue.SetActive(false);
        isSuspend = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSuspend)
            {
                OnContinueClicked();
                isSuspend = false;
            }
            else
            {
                Back.SetActive(true);
                Continue.SetActive(true);
                Time.timeScale = 0;
                isSuspend = true;
            }  
        }
        foreach (Transform tran in transform)
        {
            Vector3 pos = tran.position;
            pos.x -= Speed * Time.deltaTime;
            if (pos.x < -37.8f)
            {
                pos.x += 37.8f * 2;
            }
            tran.position = pos;
        }
    }
    public void OnContinueClicked()
    {
        Back.SetActive(false);
        Continue.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnBackClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
