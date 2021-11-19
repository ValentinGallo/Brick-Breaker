using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class LoaderLvL : MonoBehaviour {

    //Zone spawn
    float originX = -7.8f;
    float originY = 4f;

    int nbBlocks = 0;

    public Dictionary<GameObject, float> items;
    //Enemies
    public GameObject Basic;
    public GameObject Tank;
    public GameObject Malus;

    //Bonus
    public GameObject Bonus;

    public string lvlToLoad;

    void Start()
    {
    }

    public void generateLvl(int nbCol, int nbLigne){

        for (int i = 0; i < nbCol; i++)
        {
            for (int y = 0; y < nbLigne; y++){

                GameObject Generate = Basic;
                
                float spawn = Random.Range(0.00f, 1.00f);
                float percentTotal = 0.00f;
                foreach (KeyValuePair<GameObject, float> item in items)
                {
                    if(percentTotal < spawn && spawn < percentTotal+item.Value){
                        Generate = item.Key;
                        break;
                    }
                    percentTotal += item.Value;
                }
                
                Instantiate(Generate, new Vector3(originX+(i*1.3f), originY-y*0.7f, 0), Quaternion.identity);
            }
            
        }


    }

    public void removeBlock(){
        this.nbBlocks--;
        if(this.nbBlocks == 0){
            PlayerPrefs.Save();
            SceneManager.LoadScene(this.lvlToLoad);
        }
    }

    public void addBlock(){
        this.nbBlocks++;
    }

    public void generateRandomBasic(){
        float x = Random.Range(originX, 10.0f);

        Instantiate(Basic, new Vector3(x, -2, 0), Quaternion.identity);
    }
}
