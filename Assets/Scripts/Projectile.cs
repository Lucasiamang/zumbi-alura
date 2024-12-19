using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class Projectile : MonoBehaviour{
    public float Velocity = 20;
    public AudioClip SoundZombie;

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position + transform.forward * Velocity * Time.deltaTime);
    }


    void OnTriggerEnter(Collider objectCol){



        if (objectCol.tag == "Inimigo") {
            
            Destroy(objectCol.gameObject);
            AudioScript.InstanceAudio.PlayOneShot(SoundZombie);
        }

        Destroy(gameObject);
    }
}

