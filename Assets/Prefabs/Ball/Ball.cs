using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        impulsion(5f);

    }

    void impulsion(float basicSpeed){
        rb.AddForce(-transform.up * basicSpeed, ForceMode2D.Impulse);
    }

    private void FixedUpdate() {
        rb.velocity = rb.velocity.normalized * 5f;
    }

    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.name == "Wall Bot") {
            if(gameObject.name == "Ball"){
                PlayerPrefs.Save();
                SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
            }
            else{
                Destroy(gameObject);
            }

        }
    }

    public void setTransparentBall(int time){
        StartCoroutine(this.transparentBall(time));
    }

    IEnumerator transparentBall(int time){
        
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(time);
        GetComponent<CircleCollider2D>().enabled = true;
    }

    public void setBallSize(float size, int time){
        StartCoroutine(this.ballSize(size, time));
    }

    IEnumerator ballSize(float size, int time){
        
        gameObject.transform.localScale += new Vector3(size, size, 0);
        yield return new WaitForSeconds(time);
        gameObject.transform.localScale -= new Vector3(size, size, 0);
    }

    public void setAddBall(int number){

        for (int i = 0; i < number; i++)
        {
            GameObject clone = Instantiate(gameObject);
            clone.GetComponent<Renderer>().material.color = new Color32(244, 208, 63, 255);
        }
    }

    public void changeDirection(){
        rb.velocity = RandomVector(0f, 5f);
    }


    private Vector3 RandomVector(float min, float max) {
         var x = Random.Range(min, max);
         var y = Random.Range(min, max);
         var z = Random.Range(min, max);
         return new Vector3(x, y, z);
     }

}
