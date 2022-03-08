using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet_swing : MonoBehaviour
{

    [SerializeField]
    public magnet_pendulum pendulum;


    // Start is called before the first frame update
    void Start()
    {
        pendulum.Initialise();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = pendulum.MovePono(transform.localPosition, Time.fixedDeltaTime);
    }
}
