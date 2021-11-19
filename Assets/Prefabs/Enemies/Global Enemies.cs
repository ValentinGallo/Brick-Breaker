using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEnemies : MonoBehaviour
{

    
    public int hp;
    public int scoreValue = 1;

    public int hpBase;

    bool blockForWin = false;


    ParticleSystem particles;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void init(){
        LoaderLvL LoaderLvL = FindObjectOfType<LoaderLvL>();
        LoaderLvL.addBlock();
        this.hpBase = this.hp;
        this.blockForWin = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter2D(Collision2D col)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject

        if (col.gameObject.tag == "Ball")this.hit();
    }

    public void hit(){
        particles = GetComponentInChildren<ParticleSystem>();
        this.hp--;

        if(hp == 0)this.kill();

        StartCoroutine(this.showParticles());
        this.reduceColor();
    }


    void reduceColor(){
        Renderer m_ObjectRenderer = GetComponent<SpriteRenderer>();
        Color color = m_ObjectRenderer.material.color;
        float newColor = ((float)this.hp+0.5f)/hpBase;
        color.a = newColor;
        m_ObjectRenderer.material.color = color;
    }
    
    void kill(){             
        GlobalVariables GlobalVariables = FindObjectOfType<GlobalVariables>();
        GlobalVariables.AddScore(this.scoreValue);

        if(blockForWin){
            LoaderLvL LoaderLvL = FindObjectOfType<LoaderLvL>();
            LoaderLvL.removeBlock();
        }
        Destroy(gameObject);
    }

    IEnumerator showParticles()
    {
        var emission = particles.emission;
        emission.enabled = true;
        yield return new WaitForSeconds(0.5f);
        emission.enabled = false;
    }
}
