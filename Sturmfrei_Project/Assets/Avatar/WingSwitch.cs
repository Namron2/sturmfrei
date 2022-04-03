using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingSwitch : MonoBehaviour
{
    public GameObject[] ponchos;
    //public GameObject poncho1;
    //public GameObject poncho2;
    public Material[] ponchoMat;
    public SphereCollider pono;
    private float radiusIni;
    private float radiusMod;
    
    //ref playermovement pour detecter wingswitch
    public bool isFlying;
    public string state;
    PlayerMovement playerMovement;


    private void Start()
    {
        playerMovement = this.gameObject.GetComponent<PlayerMovement>();
        radiusIni = pono.radius;
        radiusMod = 0.2f;
    }

    public void Switch()
    {
        StartCoroutine(WingSwitchFX());
    }
  
    IEnumerator WingSwitchFX()
    {
        for (int i = 0; i < ponchos.Length; i++)
        {
            ponchos[i].GetComponent<Renderer>().material = ponchoMat[1];
        }
        pono.radius = radiusMod;
        //poncho1.GetComponent<Renderer>().material = ponchoMat[1];
        yield return new WaitForSeconds(0.6f);
        //poncho1.GetComponent<Renderer>().material = ponchoMat[0];
        for (int i = 0; i < ponchos.Length; i++)
        {
            ponchos[i].GetComponent<Renderer>().material = ponchoMat[0];
        }
        pono.radius = radiusIni;

    }
}
