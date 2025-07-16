using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Dialog
{
    private static Dialog instance;
    public static Dialog Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Dialog();
            }
            return instance;
        }
    }

    public List<string[]> DialogList = new List<string[]>
    {
        new string[] { "9", "0", "10", "0" },//0
        new string[] { "3", "0", "4", "0", "5", "0" },//1
        new string[] { "6", "0", "7", "0" },//2
        new string[] { "8", "0" },//3
        new string[] { "Door_1", "0" },//4
        new string[] { "12", "2" },//5
        new string[] { "13", "2" },//6
        new string[] { "11", "0" },//7
        new string[] { "14", "1", "15", "1" },//8
        new string[] { "16", "0" },//9
        new string[] { "17", "2" },//10
        new string[] { "18", "0","19", "0","20", "0", },//11
        new string[] { "25", "0"},//12
        new string[] { "22", "0", "23","2", "24","0",},//13
        new string[] { "26", "0", "27","0"},//14
        new string[] { "28", "0", "29","0"},//15
    };

    public string[] GetDialog(int index)
    {
        if (index >= 0 && index < DialogList.Count)
        {
            return DialogList[index];
        }
        else
        {
            Debug.LogWarning("Index nằm ngoài phạm vi: " + index);
            return null;
        }
    }
}

