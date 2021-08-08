using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Record: MonoBehaviour,IComparer<Record>
{
    private string name;
    private int score;
    private DateTime time;

    void Start()
    {

    }

    public Record(string name)
    {
        this.name = name;
    }

    public Record(string name, int score, DateTime time) : this(name)
    {
        this.score = score;
        this.time = time;
    }

    public string Name { get => name;}
    public int Score { get => score; set => score = value; }
    public DateTime Time { get => time; set => time = value; }

    public override string ToString()
    {
        return name + "," + score + "," + time.ToString("yyyy-MM-dd"); ;
    }

    public static List<Record> getRecords()
    {
        List<Record> records = new List<Record>();
        try
        {
            using FileStream fs = new FileStream(Application.dataPath + "/../record.txt", FileMode.OpenOrCreate);
            using StreamReader sr = new StreamReader(fs);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] infos = line.Split(',');
                records.Add(new Record(infos[0], int.Parse(infos[1]), DateTime.Parse(infos[2])));
            }
        }
        catch (Exception)
        {
            Debug.Log("打开文件出错！权限不够！");
        }
        return records;
    }

    public static void saveRecord(Record record)
    {
        try
        {
            using FileStream fs = new FileStream(Application.dataPath + "/../record.txt", FileMode.Append);
            using StreamWriter sr = new StreamWriter(fs);
            sr.Write(record.ToString());
            sr.Write("\n");
        }
        catch (Exception)
        {
            Debug.Log("打开文件出错！权限不够！");
        }
    }

    public static void clearRecords()
    {
        try
        {
            using FileStream fs = new FileStream(Application.dataPath + "/../record.txt", FileMode.Create);
            using StreamWriter sr = new StreamWriter(fs);
        }
        catch (Exception)
        {
            Debug.Log("打开文件出错！权限不够！");
        }
        Text[] texts = FindObjectsOfType<Text>();
        foreach (Text text in texts)
        {
            if (Regex.IsMatch(text.name, "cell\\d\\d"))
            {
                text.text = "";
            }
        }
    }

    public int Compare(Record x, Record y)
    {
        if (x.score > y.score)
        {
            return 1;
        }
        else if(x.score < y.score)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
