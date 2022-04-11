using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brisable : MonoBehaviour
{
    public bool isDashing;
    public ParticleSystem particule;
    public AudioSource bedingbedang;
    public PlayerCollisionSphere playMov;
    public GameObject tempo;

    public GameObject colliderTransparent;
    public GameObject colliderOpaque;
    public BoxCollider boxColliderParent;

    private void Start()
    {
        particule.Stop();
        bedingbedang = GetComponent<AudioSource>();
        colliderTransparent = GetComponentInParent<IAmInTheWay>().transparentBody;
        colliderOpaque = GetComponentInParent<IAmInTheWay>().solidBody;
    }

    private void OnTriggerEnter(Collider other)
    {
        tempo = other.gameObject;
        playMov = other.gameObject.GetComponent<PlayerCollisionSphere>();
        if (other.gameObject.tag == "Player" && other != null)
        {
            isDashing =playMov.PlayerMov.isDashing;

            if (isDashing == true)
            {
                StartCoroutine(Brise());
            }
        }
    }

    //Not sure we need to put this in a enumerator, talk to Oli
    IEnumerator Brise()
    {
        bedingbedang.Play();
        particule.Play();
        colliderOpaque.SetActive(false);
        colliderTransparent.SetActive(false);
        boxColliderParent.enabled = false;
        yield return new WaitForSeconds(1.3f);
        Destroy(transform.parent.gameObject);
        Destroy(particule);
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

}
