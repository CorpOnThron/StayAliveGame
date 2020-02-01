using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = 3;
    }

    public void GetHit(int dmg) {
        Health -=  dmg;
        if (Health < 0) RestartGame();
    
    }

    private void RestartGame() {
        Debug.Log("I should die now");
    }

}
