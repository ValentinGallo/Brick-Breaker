using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABasic : GlobalEnemies
{
    // Start is called before the first frame update
    void Start(){
        this.hp = 1;
        this.scoreValue = 1;
        
        this.init();
    }
}
