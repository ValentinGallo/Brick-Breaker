using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;


public class LoadLvl3 : LoaderLvL {

    void Start()
    {
        Cursor.visible = false;
        this.items = new Dictionary<GameObject, float>();
        
        items.Add(Tank, 0.2f);
        items.Add(Malus, 0.2f);
        items.Add(Bonus, 0.3f);

        this.generateLvl(13,6);
        
        this.lvlToLoad = "Victory";
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("Victory", LoadSceneMode.Single);
        }
    }        
}
