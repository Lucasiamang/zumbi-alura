using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour{

    private playerControl scriptPlayerControl;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        scriptPlayerControl = GameObject.FindWithTag("Player").GetComponent<playerControl>();

        healthBar.maxValue = scriptPlayerControl.Health;

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void UpdateHealthBar() {

        healthBar.value = scriptPlayerControl.Health;
    }
}