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
    public GameObject playerObject;
    public bool pressingLore;
    public bool iHaveACrystal = false;

    public GameObject controllerY;
    public GameObject keyboardF;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        CPDetectionPointObject = GameObject.Find("/"+playerObject.name.ToString() + "/Bird_Centre/FloorCheck");
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
            PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
            ControleDeCheckPoint(player);
            if (pressingLore && !iHaveACrystal)
            {
               Instantiate(crystalToSpawn, spawnPoint.position, spawnPoint.rotation);
                iHaveACrystal = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            RemoveControleDeCheckPoint();
        }
    }
    private void ControleDeCheckPoint(PlayerMovement player)
    {
        if(controllerY !=null && keyboardF != null)
        {
            controllerY.SetActive(true);
            keyboardF.SetActive(true);

            controllerY.transform.LookAt(player.Cam);
            keyboardF.transform.LookAt(player.Cam);
        }
    }

    private void RemoveControleDeCheckPoint()
    {
        if (controllerY != null && keyboardF != null)
        {
            controllerY.SetActive(false);
            keyboardF.SetActive(false);
        }
    }
}
