using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonchoCooldown : MonoBehaviour
{

    //references
    public Material ponchoMaterial;
    public GameObject player;
    public GameObject poncho;
    public float recharge;


    //couleurs d'emission gradient lerp
    public Color couleurPoncho;
    public Color coul1;
    public Color coul2;
    public Color coulTrans;
    public Gradient gradientPoncho;
    public float startTime;
    public float vitesse;

    //intensite de l'emission : connecte a cooldown progress
    public float intensity;

    //particules
    public GameObject aether;
    public GameObject aetherBurst;
    public bool dashFull = false;

    private void Start()
    {
        poncho = this.gameObject;
        ponchoMaterial = poncho.GetComponent<Renderer>().material;
        //recharge = player.GetComponent<PlayerMovement>().progress;

        //coul1 = Color.HSVToRGB(0.51f, 0.54f, 1.0f); //bleu //voir aether pour les couleurs exactes
        //coul2 = Color.HSVToRGB(0.85f, 0.75f, 1.0f); //rose
        startTime = Time.time;

        ponchoMaterial.EnableKeyword("_EMISSION");
        player = poncho.transform.root.gameObject;

        aether = poncho.transform.GetChild(0).gameObject;
        aetherBurst = poncho.transform.GetChild(1).gameObject;
        
        // // //besoin de changer la valeur de base de progress dans playermovement a 1 pour le debut
    }
    private void Update()
    {
        // link vers le cooldown
        recharge = player.GetComponent<PlayerMovement>().progress;

        //lerp de couleur sur le poncho
        //couleurPoncho = Color.Lerp(coul1, coul2, Mathf.Sin(Time.time * vitesse)) ;
        float t = Mathf.Sin(Time.time*vitesse);
        couleurPoncho = gradientPoncho.Evaluate(t);

        //intensity est affecte par cooldown : devient invisible a utilisation
        intensity = recharge * 2.0f + 0.0f;
        ponchoMaterial.SetColor("_EmissionColor", couleurPoncho * intensity);

        if (recharge >= 1.00f)
        {
            if (dashFull == false)
            {
                dashFull = true;
                ParticleDash();
            }
            aether.GetComponent<ParticleSystem>().Play();

        }

        if (recharge < 0.99f)
        {
            aether.GetComponent<ParticleSystem>().Pause();
            dashFull = false;
        }
    }
   
   void ParticleDash()
    {
        if (dashFull == true)
        {
            aetherBurst.GetComponent<ParticleSystem>().Play();

        }
    }
}
