using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMalus : GlobalEnemies
{
    User user;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        this.hp = 1;
        this.scoreValue = 1;

        user = FindObjectOfType<User>();
        ball = FindObjectOfType<Ball>();

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        this.malus();
        if (col.gameObject.tag == "Ball")this.hit();
    }

    void malus(){
        int rand = Random.Range(0, 2);

        if(rand == 0){
            user.setUpgradeLarger(-1,5);

        }
        else if(rand == 1){
            this.addEnnemie();
        }

    }

    public void addEnnemie(){
        LoaderLvL LoaderLvL = FindObjectOfType<LoaderLvL>();
        LoaderLvL.generateRandomBasic();
    }


}
