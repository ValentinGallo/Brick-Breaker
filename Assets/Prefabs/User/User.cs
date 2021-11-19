using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public GameObject Ailes;
    float horizontalInput;
    public float horizontalMultiplier = 2;
    public Rigidbody2D rb;
    public float speed = 5;

    double limiteGauche = -8.07;
    double limiteDroite = 8.07;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        double posX = transform.position.x;
        Vector2 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector2 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;

        /*
         *  Permet d'éviter de sortir de la zone de jeu
        */
        if(posX >= limiteGauche && posX <= limiteDroite) {
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        } else if (posX <= limiteGauche && horizontalMove.x > 0.00) {
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        } else if (posX >= limiteDroite && horizontalMove.x < 0.00) {
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }
    }

    public void setUpgradeLarger(int size, int time){
         StartCoroutine(this.upgradeLarger(size,time));
    }

    IEnumerator upgradeLarger(int size, int time){

        gameObject.transform.localScale += new Vector3(size, 0, 0);
        yield return new WaitForSeconds(time);
        
        gameObject.transform.localScale += new Vector3((size*-1), 0, 0);
        
    }

    public void generateAiles(int time){
        StartCoroutine(this.addAiles(time));
    }

    IEnumerator addAiles(int time){
        GameObject clone = Instantiate(Ailes);
        yield return new WaitForSeconds(time);
        Destroy(clone);
    }

    public void setSpeedUp(float speedUp, int time){
        StartCoroutine(this.changeSpeed(speedUp, time));
    }

    IEnumerator changeSpeed(float speedUp, int time){
        this.speed = speed + speedUp*speed;
        yield return new WaitForSeconds(time);
        this.speed = speed - speedUp*speed;
    }
}
