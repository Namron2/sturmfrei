using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    [Header("Test String Event Name")]
    [SerializeField] private string walkingAnimationEvent;
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
    }

    void WalkingAnimation()
    {
        print("Walking Event Call");
        AkSoundEngine.PostEvent(walkingAnimationEvent, gameObject);
    }

}
