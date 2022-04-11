using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Pollution : MonoBehaviour
{

    private GameObject playerObject;
    public PlayerCollisionSphere playMovScript;
    private bool asPurifiability;
    private void OnTriggerStay(Collider other)
    {
        playerObject = other.gameObject;
        playMovScript = other.gameObject.GetComponent<PlayerCollisionSphere>();
        if (other.gameObject.tag == "Player" && other != null)
        {
            asPurifiability = playMovScript.PlayerMov.purificationAbility;

            if (asPurifiability == true)
            {
                playMovScript.PlayerMov.Purify();
            }
            else
            {
                playMovScript.PlayerMov.Tainted();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerObject = other.gameObject;
        playMovScript = other.gameObject.GetComponent<PlayerCollisionSphere>();
        if (other.gameObject.tag == "Player" && other != null)
        {
            asPurifiability = playMovScript.PlayerMov.purificationAbility;

            if (asPurifiability == false)
            {
                playMovScript.PlayerMov.Detox();
            }
        }
    }
}
