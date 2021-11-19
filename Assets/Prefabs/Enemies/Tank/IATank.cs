using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IATank : GlobalEnemies
{
    // Start is called before the first frame update
    void Start()
    {
        this.hp = 3;
        this.scoreValue = 5;
        this.init();
    }
}
