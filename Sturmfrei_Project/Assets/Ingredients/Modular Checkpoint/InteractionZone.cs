using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    const float detectionRadius = 0.2f;
    public LayerMask checkPointZone;
    private Transform CPDetectionPoint; // CP = checkpoint
    private GameObject CPDetectionPointObject; // CP = checkpoint
    public Transform spawnPoint;
    public GameObject crystalToSpawn;
    public GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        CPDetectionPointObject = GameObject.Find("/"+player.name.ToString() + "/Bird_Centre/FloorCheck");
        CPDetectionPoint = CPDetectionPointObject.transform;
        spawnPoint = this.gameObject.transform;
    }
    private void Update()
    {
        /*if (DetectCheckPointZone())
        {
            if (InteractInput())
            {
                Vector3 SpawnPoint = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 1, spawnPoint.position.z);
                Debug.Log("A crystal appears");
                Instantiate(crystalToSpawn, SpawnPoint, spawnPoint.rotation);
            }
        }*/
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }

    /*bool DetectCheckPointZone()
    {
        Vector3 Pos = CPDetectionPoint.position;
        Collider[] hitColliders = Physics.OverlapSphere(Pos, detectionRadius, checkPointZone);
        if (hitColliders.Length > 0)
        {
            return true;
        }

        return false;

    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            if (InteractInput())
            {
                Vector3 SpawnPoint = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 1, spawnPoint.position.z);
                Debug.Log("A crystal appears");
                Instantiate(crystalToSpawn, SpawnPoint, spawnPoint.rotation);
            }
        }
    }


}
