using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ability_Unlock : MonoBehaviour
{
    //public UnityEvent Unlock_Time;
    public GameObject Objet_A_Regarder;
    float tempsDeLookAt;

    private CameraFollowTarget camFolTar;
    private CameraFollow camFol;
    private PlayerMovement player;

    private void Start()
    {
        tempsDeLookAt = 3;
        camFolTar = GameObject.Find("CameraFollow").GetComponent<CameraFollowTarget>();
        player = GameObject.Find("PonoPrefab#03").GetComponent<PlayerMovement>();
        camFol = camFolTar.gameObject.GetComponent<CameraFollow>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Objet_A_Regarder != null)
        {
            camFol.wallObject = Objet_A_Regarder;
            StartCoroutine(RegardeObjet());
        }
    }

    public IEnumerator RegardeObjet()
    {
        
        camFolTar.lookingAtWall = true;
        // Stop player control
        player.enabled = false ;
        //stop animation
        yield return new WaitForSeconds(tempsDeLookAt);
        // give back player control
        player.enabled = true;
        //Return cam
        camFolTar.lookingAtWall = false;
        Destroy(this.gameObject);
    }
}
