using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    private AudioSource privateAudio;
    public static AudioSource InstanceAudio;

    private void Awake() {
        
        privateAudio = GetComponent<AudioSource>();
        InstanceAudio = privateAudio;

    }


}

