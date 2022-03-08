using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicWaterfall : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * -50f);
    }
}
