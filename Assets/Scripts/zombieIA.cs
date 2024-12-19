using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class zombieIA : MonoBehaviour {

    public GameObject Player;
    public float Velocity = 3.5f;


    //start is called before the first frame update
    void Start()
    {
        //when spawning, it locks on to the player
        Player = GameObject.FindWithTag("Player");

        //randomizing skins when spawning
        int ZombieType = Random.Range(1, 28);
        transform.GetChild(ZombieType).gameObject.SetActive(true);

    }

    //update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){

        float distance = Vector3.Distance(transform.position, Player.transform.position);
        Vector3 direction = Player.transform.position - transform.position;

        //updating where it should be looking
        Quaternion newRotation = Quaternion.LookRotation(direction);

        //rotating it
        GetComponent<Rigidbody>().MoveRotation(newRotation);

        if (distance > 2.3) {

            //making it move towards the player
            GetComponent<Rigidbody>().MovePosition
                (GetComponent<Rigidbody>().position + direction.normalized * Velocity * Time.deltaTime);

            GetComponent<Animator>().SetBool("Attacking", false);

        }
        else{

            GetComponent<Animator>().SetBool("Attacking", true);

        }
        
       

    }

    void AttackPlayer() {

        //randomize the damage and gives the value to the HealthUpdate in playerControl
        int damage = Random.Range(20, 30);

        Player.GetComponent<playerControl>().HealthUpdate(damage);

    }


}
