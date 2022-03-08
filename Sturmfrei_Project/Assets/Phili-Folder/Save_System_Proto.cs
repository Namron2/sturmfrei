using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save_System_Proto : MonoBehaviour
{
    public Text Text_Centre;
    public static int number = 0;


    private void Start()
    {
        Text_Centre.text = "0";

    }
    public void IncreaseNumber()
    {
        number += 1;
        Text_Centre.text = number.ToString();
    }

    public void Save()
    {
        Save_System.SaveNumber(number);
    }

    public void Load()
    {
        Save_Data_Proto data = Save_System.LoadData();
        number = data.number;
        Text_Centre.text = number.ToString();
    }
}
