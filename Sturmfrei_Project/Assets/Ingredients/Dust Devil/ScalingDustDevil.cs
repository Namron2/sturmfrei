using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScalingDustDevil : MonoBehaviour
{
    //scaling de l'objet
    public Collider dustCollider;
    public ParticleSystem ventParticules;

    //general
    public float hauteur = 1;
    public float rayon = 1;
  
    private void Update()
    {
        dustCollider.GetComponent<CapsuleCollider>().radius = rayon * 2.5f;
        dustCollider.GetComponent<CapsuleCollider>().height = hauteur * 40f;

        //rayon particules
        var particleShape = ventParticules.GetComponent<ParticleSystem>().shape;
        particleShape.scale = new Vector3(4f*rayon, 4f * rayon, 1f);

        //hauteur particules
        var particuleMain = ventParticules.GetComponent<ParticleSystem>();
        particuleMain.startLifetime = 3.5f * hauteur;
    }
}
