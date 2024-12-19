using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour {

    Vector3 movement;
    //to multiply base velocity
    public float velMultiplier = 8.6f;
    public GameObject TextGameOver;
    public bool Alive = true;
    public LayerMask FloorMask;
    public int Health = 100;
    public UI scriptUI;
    public AudioClip DamageSound;



    private void Start() {
       
        Time.timeScale = 1.0f;
    }



    void Update() {
        //inputing axis
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        //updating according to inputs
         movement = new Vector3(eixoX, 0, eixoZ);

        
        //transforming in movement per second

        //for changing idle > walk
        if(movement != Vector3.zero){

            GetComponent<Animator>().SetBool("WalkTrigger", true);
         }
        else{
            GetComponent<Animator>().SetBool("WalkTrigger", false);
        }        
        
        //restart the game when dead, doesnt work inside HealthUpdate
        if (Health <= 0) {

            if (Input.GetMouseButtonDown(0)) {

                SceneManager.LoadScene("ruaCasa");

            }

        }

    }




   void FixedUpdate() {

        //creating Ray collision
        RaycastHit hit;

        //movement per second
        GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position + (Time.deltaTime * velMultiplier * movement));

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        //making the character look at the Ray collision
        if (Physics.Raycast(camRay,out hit, 100, FloorMask)){

            Vector3 posAimPlayer = hit.point - transform.position;

            //making the character not look to the ground
            posAimPlayer.y = transform.position.y;

            //updating the aim position
            Quaternion newRotation = Quaternion.LookRotation(posAimPlayer);

            GetComponent<Rigidbody>().MoveRotation(newRotation);
                                    
        }

    }

    public void HealthUpdate (int damage){

        //update health with damage imported from zombieAI.
        Health -= damage;

        scriptUI.UpdateHealthBar();

        AudioScript.InstanceAudio.PlayOneShot(DamageSound);

       
        if(Health < 0) {

            Time.timeScale = 0.007f;
            TextGameOver.SetActive(true);

        }

    }





}
