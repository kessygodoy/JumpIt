using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string cena;
    public int faseAtual;
    public Text txtFaseCompletada;

    void Awake()
    {
      
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuFases");
    }

}
