using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseAudioEmitter : MonoBehaviour
{
    public string eventName = "default";
    public string stopEvent = "default";
    private bool isInCollider = false;

    void Start()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" || isInCollider == true) { return; }
        isInCollider = true;
        AkSoundEngine.PostEvent(eventName, gameObject);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" || isInCollider == false) { return; }
        isInCollider = false;
        AkSoundEngine.PostEvent(stopEvent, gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" || isInCollider == true) { return; }
        isInCollider = true;
        AkSoundEngine.PostEvent(eventName, gameObject);
    }
}
