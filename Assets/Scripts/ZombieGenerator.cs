using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    public GameObject ZombieGen;
    float timeCounter = 0;
    public float ZombieTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;

        if(timeCounter >= ZombieTime) {

            Instantiate(ZombieGen, transform.position, transform.rotation);
            timeCounter = 0;

        }
        
    }
}
