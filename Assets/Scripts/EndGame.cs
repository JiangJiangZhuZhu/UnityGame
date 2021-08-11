using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Record record = new Record(Global.name, (int)Global.score, Global.dateTime);
        Record.saveRecord(record);
    }
}
