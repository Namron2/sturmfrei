using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockPurify : MonoBehaviour
{
    public GameObject pono;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pono = GameObject.Find("PonoPrefab#03");
            pono.GetComponent<PlayerMovement>().purificationAbility = true;
        }
    }
}
