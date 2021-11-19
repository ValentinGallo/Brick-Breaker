using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;


public class LoadLvl1 : LoaderLvL {

    void Start()
    {
        Cursor.visible = false;
        this.items = new Dictionary<GameObject, float>();
        
        items.Add(Tank, 0f);
        items.Add(Malus, 0f);
        items.Add(Bonus, 0.4f);

        //13,2
        this.generateLvl(13,2);
        
        this.lvlToLoad = "Level 2";
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
        }
    }
}
