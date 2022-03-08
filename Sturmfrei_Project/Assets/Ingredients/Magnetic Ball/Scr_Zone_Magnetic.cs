using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Zone_Magnetic : MonoBehaviour
{
    public PonchoColourChange sturm;
    private void OnTriggerEnter(Collider other)
    {
        sturm.GoldPoncho();
    }
    private void OnTriggerExit(Collider other)
    {
        sturm.NoMoreGold();
    }
}
