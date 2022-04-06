using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonchoColourChange : MonoBehaviour
{
    //Renderer renderPoncho;
    //Renderer renderPonchoMain;
    //public GameObject playerPonchoMain;
    //public GameObject playerPonchoPart;
    //public Texture2D texPonchoClassic;
    //public Texture2D texPonchoGold;

    //private void Start()
    //{
    //    // Getting the componenets to which textures should be changed
    //    renderPonchoMain = playerPonchoMain.GetComponent<Renderer>();
    //    renderPoncho = playerPonchoPart.GetComponent<Renderer>();

    //    //Setting basic texture
    //    renderPoncho.material.SetTexture("_MainTex", texPonchoClassic);
    //    renderPonchoMain.material.SetTexture("_MainTex", texPonchoClassic);
    //}
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        ColourChange();
    //    }
    //}

    //void ColourChange()
    //{
    //    renderPoncho.material.SetTexture("_MainTex", texPonchoGold);
    //    renderPonchoMain.material.SetTexture("_MainTex", texPonchoGold);
    //}

    /// <summary>
    /// ////////////////////////////////////////////////////////
    /// </summary>
    /// 
    //Renderer renderPoncho;
    //Renderer renderPonchoMain;
    //[SerializeField] private Texture2D ponchoMaterial;
    //[SerializeField] private Texture2D ponchoMaterialGold;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Soul"))
    //    {
    //        renderPoncho.material.SetTexture("_MainTex", ponchoMaterialGold);
    //        renderPonchoMain.material.SetTexture("_MainTex", ponchoMaterialGold);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Soul"))
    //    {
    //        renderPoncho.material.SetTexture("_MainTex", ponchoMaterial);
    //        renderPonchoMain.material.SetTexture("_MainTex", ponchoMaterial);
    //    }
    //}

    ///////////////////////////////

    //Renderer renderPoncho;
    //public Material[] texturePoncho;

    //private void Start()
    //{
    //    renderPoncho = GetComponent<Renderer>();
    //    renderPoncho.enabled = true;
    //    renderPoncho.sharedMaterial = texturePoncho[0];
    //}

    //private void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Soul")
    //    {
    //        renderPoncho.sharedMaterial = texturePoncho[1];
    //    }

    //    else
    //    {
    //        renderPoncho.sharedMaterial = texturePoncho[2];
    //    }
    //}

    ////////////////////////////////////
    public Renderer renderPoncho;
    public Renderer renderPonchoCollar;
    public Material[] texturePoncho;

    private void Start()
    {
        //renderPoncho = GetComponent<Renderer>();
        //renderPoncho.enabled = true;
        if (renderPoncho != null || renderPonchoCollar != null)
        {
            renderPoncho.sharedMaterial = texturePoncho[0];
            renderPonchoCollar.sharedMaterial = texturePoncho[0];
        }

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            GoldPoncho();
        }

        if (Input.GetKey(KeyCode.O))
        {
            NoMoreGold();
        }
    }
    public void GoldPoncho()
    {
        if (renderPoncho != null || renderPonchoCollar != null)
        {
            renderPoncho.sharedMaterial = texturePoncho[1];
            renderPonchoCollar.sharedMaterial = texturePoncho[1];
        }
        Debug.Log("Gold");
    }
    public void NoMoreGold()
        {
        if (renderPoncho != null || renderPonchoCollar != null)
        {
            renderPoncho.sharedMaterial = texturePoncho[0];
            renderPonchoCollar.sharedMaterial = texturePoncho[0];
        }
        Debug.Log("Shoot, gold is gone");
    }
   

    ////////////////////////////////////

    //Renderer renderPoncho;
    //public Material[] texturePoncho;
    //public LayerMask soul;

    //private void Start()
    //{
    //    renderPoncho = GetComponent<Renderer>();
    //    renderPoncho.enabled = true;
    //    renderPoncho.sharedMaterial = texturePoncho[0];
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if ((soul.value & 7 << other.gameObject.layer) == 7 << other.gameObject.layer)
    //    {
    //        renderPoncho.sharedMaterial = texturePoncho[1];
    //    }
    //}

    /////////////////////////////////////////////
    ///
    //Renderer renderPoncho;
    //Renderer renderPonchoMain;
    //[SerializeField] private Texture2D ponchoMaterial;
    //[SerializeField] private Texture2D ponchoMaterialGold;
    //public GameObject playerPonchoMain;
    //public GameObject playerPonchoPart;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Soul"))
    //    {
    //        Debug.Log("Gold");
    //        renderPoncho = GetComponent<Renderer>();
    //        renderPoncho.enabled = true;
    //        renderPoncho.material.SetTexture("_MainTex", ponchoMaterialGold);
    //        renderPonchoMain.material.SetTexture("_MainTex", ponchoMaterialGold);
    //    }
    //}
}
