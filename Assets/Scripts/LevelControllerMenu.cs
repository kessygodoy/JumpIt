using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControllerMenu : MonoBehaviour
{
    public string cena;
    public int faseAtual;
    public Button[] botaoFase;
    private int fasesPassadas;
    private LevelController _level;

    void Start()
    {
        _level = FindObjectOfType<LevelController>();
        faseAtual = _level.faseAtual;

        fasesPassadas = PlayerPrefs.GetInt("FasesPassadas");

        
       for(int i = 0; i < fasesPassadas; i++)
        {
            botaoFase[i].interactable = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string cena)
    {
        SceneManager.LoadScene(cena);
    }


}
