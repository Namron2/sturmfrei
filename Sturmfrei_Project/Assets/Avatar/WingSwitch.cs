using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingSwitch : MonoBehaviour
{
    public GameObject[] ponchos;
    public Material[] ponchoMat;
    private SphereCollider pono;
    private float radiusIni;
    private float radiusMod;
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = this.gameObject.GetComponent<PlayerMovement>();
        pono = playerMovement.Rigid.gameObject.GetComponent<SphereCollider>();
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
