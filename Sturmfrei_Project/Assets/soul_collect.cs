using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soul_collect : MonoBehaviour
{
    public AudioSource collectsound;
    private PlayerCollisionSphere playCol;
    private PlayerMovement playerMov;
    private PonchoColourChange ponchoColor;

   private void OnTriggerEnter(Collider other)
    {
        playCol = other.GetComponent<PlayerCollisionSphere>();
        playerMov = playCol.PlayerMov;
        ponchoColor = playerMov.gameObject.GetComponent<PonchoColourChange>();
        ponchoColor.GoldPoncho();
        collectsound.Play();
        StartCoroutine(detroy());
    }

    private IEnumerator detroy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        
    }
}


