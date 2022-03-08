using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReglageVitesse : MonoBehaviour
{
    //float dans l'inspecteur multiplie la vitesse standard de l'animator sans modifier l'anim ou le controller
    public float speedMultiplier;
    public Animator animEolienne;

    private void Start()
    {
        animEolienne = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        animEolienne.speed = speedMultiplier;
    }
}
