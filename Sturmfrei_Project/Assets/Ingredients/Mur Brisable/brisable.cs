using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brisable : MonoBehaviour
{
    public bool isDashing;
    public GameObject particule;
    public AudioSource bedingbedang;
    public PlayerCollisionSphere playMov;
    public GameObject tempo;

    public GameObject colliderTransparent;
    public GameObject colliderOpaque;
    public BoxCollider boxColliderParent;

    private void Start()
    {
        particule.SetActive(false);
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
        particule.SetActive(true);
        colliderOpaque.SetActive(false);
        colliderTransparent.SetActive(false);
        boxColliderParent.enabled = false;
        yield return new WaitForSeconds(1.3f);
        Destroy(transform.parent.gameObject);
        Destroy(particule);
        Destroy(this.gameObject);
    }

}
