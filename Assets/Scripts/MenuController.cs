using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Small behaviour to handle menu button callbacks.
 */
public class MenuController : MonoBehaviour
{
    private void Start()
    {
        List<Record> records = Record.getRecords();
        int i = 0;
        Debug.Log("回到了结束界面");
        Text[] texts = FindObjectsOfType<Text>();
        records.Sort(
        delegate (Record a, Record b)
        {
            return b.Score.CompareTo(a.Score);
        });
        foreach (Record record in records)
        {
            if (i >= 5)
            {
                break;
            }
            foreach(Text text in texts)
            {
                Debug.Log(text.name);
                if (text.name.Equals("cell" + i + "0"))
                {
                    text.text = record.Name;
                }
                if (text.name.Equals("cell" + i + "1"))
                {
                    text.text = record.Score.ToString();
                }
                if (text.name.Equals("cell" + i + "2"))
                {
                    text.text = record.Time.ToString("yyyy-MM-dd");
                }
            } 
            i++;
        }
        
    }
    /*
     * When the start button is pressed, load the Game scene.
     */
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
}
