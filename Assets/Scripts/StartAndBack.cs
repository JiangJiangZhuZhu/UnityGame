using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAndBack : MonoBehaviour
{
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartClicked()
    {
        SceneManager.LoadScene("Game");
    }

    /*
     * When the back button is clicked, load the Menu scene.
     */
    public void OnBackClicked()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
}
