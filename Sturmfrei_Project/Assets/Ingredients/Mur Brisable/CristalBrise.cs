using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalBrise : MonoBehaviour
{
    public bool isDashing;
    public bool isDestroyed = false;
    public PlayerCollisionSphere playMov;
    public GameObject tempo;
    public GameObject cristal;
    public GameObject cristalBrisé;
    public GameObject[] rocks;

    private void Start()
    {
        cristalBrisé.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        tempo = other.gameObject;
        playMov = other.gameObject.GetComponent<PlayerCollisionSphere>();
        if (other.gameObject.tag == "Player" && other != null && isDestroyed == false)
        {
            isDashing = playMov.PlayerMov.isDashing;

            if (isDashing == true)
            {
                StartCoroutine(Brise());
            }
        }
    }
    IEnumerator Brise()
    {
        cristal.transform.parent.GetComponent<Animator>().enabled = false;
        cristal.SetActive(false);
        cristalBrisé.SetActive(true);
        cristalBrisé.GetComponent<ParticleSystem>().Play();
        isDestroyed = true;
        DropRocks();
        yield return null;
    }

    void DropRocks()
    {
        for (int i = 0; i < rocks.Length; i++)
        {
            rocks[i].GetComponent<Rigidbody>().useGravity = true;
            rocks[i].transform.parent = null;
        }
    }
}
