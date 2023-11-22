using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set;}

    public int vidas;

    public HUD hud;

    public int pointsTotal {get; private set;}

    private int hp = 3;

    public int val = 0;

    public StarCollect stur;
    
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }    
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void HPLoss()
    {
        hp -= 1;

        if(hp == 0)
        {
            SceneManager.LoadScene(2);
        }
        
        hud.DesactivarVidas(hp);

    }

    public void WinnerScene()
    {
        val += 1;
        
        if(val == 1)
        {
            SceneManager.LoadScene(1);
        }
        
    }
}
