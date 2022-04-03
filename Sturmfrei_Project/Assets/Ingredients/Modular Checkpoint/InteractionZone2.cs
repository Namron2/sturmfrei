using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZone2 : MonoBehaviour
{
    public LayerMask checkPointZone;
    private Transform CPDetectionPoint; // CP = checkpoint
    private GameObject CPDetectionPointObject; // CP = checkpoint
    public Transform spawnPoint;
    public GameObject player;
    public bool pressingLore;
    public GameObject shrine;
    public GameObject crystalToSpawn;
    public ParticleSystem aetherFX;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        CPDetectionPointObject = GameObject.Find("/"+player.name.ToString() + "/Bird_Centre/FloorCheck");
        CPDetectionPoint = CPDetectionPointObject.transform;     

    }

    public void Update()
    {
        pressingLore = Input.GetButton("Save");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            shrine.GetComponent<Animator>().SetBool("PonoProche", true);

            Debug.Log("Press F on keyboard or Y on controller");
            if (pressingLore)
            {
                shrine.GetComponent<Animator>().SetTrigger("SetCheckpoint");
                Instantiate(crystalToSpawn, spawnPoint.position, spawnPoint.rotation);
                StartCoroutine(Aether());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shrine.GetComponent<Animator>().SetBool("PonoProche", false);
        }
    }

    IEnumerator Aether()
    {
        aetherFX.Play();
        yield return new WaitForSeconds(2f);
        //aetherFX.Stop();
    }

}
