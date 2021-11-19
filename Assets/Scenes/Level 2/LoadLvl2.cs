using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;


public class LoadLvl2 : LoaderLvL {

    void Start()
    {
        Cursor.visible = false;
        this.items = new Dictionary<GameObject, float>();
        
        items.Add(Tank, 0.1f);
        items.Add(Malus, 0.05f);
        items.Add(Bonus, 0.3f);

        this.generateLvl(13,4);
        
        this.lvlToLoad = "Level 3";
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
        }
    }    
}
