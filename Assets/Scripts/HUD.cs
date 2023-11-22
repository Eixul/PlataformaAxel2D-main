using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI points;
    public GameObject[] vidas;
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ActualizarPuntos(int pointsTotal)
    {
        points.text = pointsTotal.ToString();
    }
    
    public void DesactivarVidas(int index)
    {
        vidas[index].SetActive(false);
    }

    public void ActivarVidas(int index)
    {
        vidas[index].SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
