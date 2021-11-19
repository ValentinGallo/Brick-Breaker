using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{   

    User user;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        user = FindObjectOfType<User>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerEnter2D(Collider2D col)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (col.gameObject.tag == "Ball"){
            giveBonus();
            Destroy(gameObject);
        }
    }

    void giveBonus(){
        int rand = Random.Range(0, 4);

        if(rand == 0){
            user.setUpgradeLarger(1,10);
        }
        else if(rand == 1){
            ball.setBallSize(0.25f, 10);
        }
        else if(rand == 2){
            int number = Random.Range(1, 3);
            ball.setAddBall(number);
        }
        else if(rand == 3){
            user.generateAiles(7);
        }
    }
}
