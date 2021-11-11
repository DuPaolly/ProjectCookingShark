using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTest : MonoBehaviour
{

    [SerializeField] Positions posicaoParaIr;

    Positions posicaoDetectada;

    [SerializeField] int[] randomSpawn;

    float tempoSpawnando = 4;

    float tempoDeSpawn = 0;
    
    bool podeSpawnar = false;

    private Vector3 _originalPosition;

    private Vector3 _posicaoFinal;

    private Vector2 offset, _posicaoAtual;


    [SerializeField] [Range(0, 1)] float smoothVelocidade = 1;

    // Start is called before the first frame update
    void Awake()
    {
        _originalPosition = transform.position;
        tempoDeSpawn = 0;
        CreatRandomSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        Spawner();
        TestSpawn();
    }

    private void OnTriggerEnter2D(Collider2D areaEmQueEntrou)
    {
        Positions algoDetectado = areaEmQueEntrou.GetComponent<Positions>();

        if(areaEmQueEntrou != null)
        {
            posicaoDetectada = algoDetectado;
        }
    }

    private void OnTriggerExit2D(Collider2D areaEmQueSaiu)
    {
        Positions algoDetectado = areaEmQueSaiu.GetComponent<Positions>();

        if (algoDetectado != null)
        {
            posicaoDetectada = null;
        }
    }

    void Spawner()
    {   
        if (podeSpawnar == false)
        {
            tempoDeSpawn += Time.deltaTime;
            Debug.Log(tempoDeSpawn);
            if(tempoDeSpawn >= tempoSpawnando)
            {
                podeSpawnar = true;
            }
        }
    }

    public void TestSpawn()
    {
        if(podeSpawnar == true)
        {
            MoverPara(posicaoParaIr);
            if (posicaoDetectada != null)
            {
                CreatRandomSpawnTime();
                podeSpawnar = false;
                transform.position = _originalPosition;
            }
        }      
    }

    public void MoverPara(Positions posicao)
    {
        if (podeSpawnar == true)
        {
            _posicaoFinal = posicao.transform.position;

            _posicaoAtual = transform.position;

            _posicaoAtual = Vector3.Lerp(
                transform.position,
                _posicaoFinal,
                smoothVelocidade * Time.deltaTime);

            transform.position = _posicaoAtual;
        }
    }
    private bool PodeVoltarAPosiçãoInicial()
    {
        return true;
    }

    private bool JaChegouNoDestino()
    {
        return false;
    }

    void CreatRandomSpawnTime()
    {
        tempoSpawnando = randomSpawn[SortearLocal()];
        Debug.Log(tempoSpawnando);
    }

    public int SortearLocal()
    {
        tempoDeSpawn = 0;
        return Random.Range(0, randomSpawn.Length);
    }

}
