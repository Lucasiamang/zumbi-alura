using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour{

    public GameObject Player;
    Vector3 distancePlayer;

    // Start is called before the first frame update
    void Start(){
        
        distancePlayer = transform.position - Player.transform.position;

       
    }

    // Update is called once per frame
    void Update(){
        
        transform.position = Player.transform.position + distancePlayer;



    }
}
