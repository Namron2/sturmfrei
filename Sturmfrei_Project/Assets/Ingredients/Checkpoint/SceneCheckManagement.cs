using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCheckManagement : MonoBehaviour
{
    public GameObject[] Zones;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           for (int i = 0; i < Zones.Length; i++)
            {
                Zones[i].SetActive(false);
            }
        }
    }
}
