using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentEolienne : MonoBehaviour
{
    public int burstValue = 20;

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Rigidbody>().AddForce((-transform.up * burstValue), ForceMode.Impulse);
            //-transform.up pousse en avant a cause de la direction du collider capsule
        }
    }
}
