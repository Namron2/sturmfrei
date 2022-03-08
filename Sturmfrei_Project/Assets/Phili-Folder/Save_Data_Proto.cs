using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save_Data_Proto 
{
    public int number;

    public Save_Data_Proto(int data_proto)
    {
        number = Save_System_Proto.number;
    }
}
