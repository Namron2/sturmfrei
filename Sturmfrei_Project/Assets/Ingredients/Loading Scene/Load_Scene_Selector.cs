using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Load_Scene_Selector : MonoBehaviour
{
    // list des scene en string
    public UnityEvent Test;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Test.Invoke();
        }
    }
}
