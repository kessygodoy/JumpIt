using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerInfinity : MonoBehaviour
{

    private PlayerController pl;

    public float tamanhoMapa;
    public GameObject geradorDeMapas;
    public Transform positionnextGenerator;

    public float yNextMap = 8.6f;
    

    public GameObject[] mapas;
    void Start()
    {
        pl = FindObjectOfType<PlayerController>();
        GameObject mapaTemporario = Instantiate(mapas[Random.Range(0, mapas.Length)]);
        mapaTemporario.transform.position = new Vector2(-4.45f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (pl.transform.position.y >= yNextMap)
        {
            yNextMap += tamanhoMapa;
            GeraNovoMapa(yNextMap);
        }
       
    }

    public void GeraNovoMapa(float nextMapY)

    {

        GameObject mapaTemporario = Instantiate(mapas[Random.Range(0, mapas.Length -1)]);
        mapaTemporario.transform.position = new Vector2(-4.5f,  nextMapY);
        //GameObject GeradorDeMapaTemp = Instantiate(geradorDeMapas);

        //GeradorDeMapaTemp.position = geradorDeMapas.transform.position +
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerInfinity : MonoBehaviour
{

    private PlayerController pl;

    public float tamanhoMapa;
    public GameObject geradorDeMapas;
    public Transform positionnextGenerator;

    public float yNextMap = 8.6f;
    

    public GameObject[] mapas;
    void Start()
    {
        pl = FindObjectOfType<PlayerController>();
        GameObject mapaTemporario = Instantiate(mapas[Random.Range(0, mapas.Length)]);
        mapaTemporario.transform.position = new Vector2(-4.45f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (pl.transform.position.y >= yNextMap)
        {
            yNextMap += tamanhoMapa;
            GeraNovoMapa(yNextMap);
        }
       
    }

    public void GeraNovoMapa(float nextMapY)

    {

        GameObject mapaTemporario = Instantiate(mapas[Random.Range(0, mapas.Length -1)]);
        mapaTemporario.transform.position = new Vector2(-4.5f,  nextMapY);
        //GameObject GeradorDeMapaTemp = Instantiate(geradorDeMapas);

        //GeradorDeMapaTemp.position = geradorDeMapas.transform.position +
    }
}
*/