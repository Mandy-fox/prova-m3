using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlvoManager : MonoBehaviour
{
    public static AlvoManager instance;

    [SerializeField] private Alvo alvo;
    [SerializeField] float timerToSpawn;
    [SerializeField] TextMeshProUGUI scoreText;

    private float screenWidth;
    private float screenHeigh;


    public Queue<Alvo> existingAlvos = new Queue<Alvo>();
    public static int score;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        screenHeigh = 5;
        screenWidth = 2.4f;

        StartCoroutine(CreateNewAlvo());
        DestroyAlvo();
    }

    IEnumerator CreateNewAlvo()
    {
        while (true)
        {

            GenerateAlvo();
            yield return new WaitForSeconds(timerToSpawn);
        }
    }


    public void DestroyAlvo()
    {
        if (existingAlvos.Count == 0)
        {
            GenerateAlvo();
        }
        var thisAlvo = existingAlvos.Dequeue();
        thisAlvo.sR.color = Color.yellow;
        thisAlvo.isActive = true;

        DestroyAlvo();

    }

    public void UpdtUI()
    {
        scoreText.text = score.ToString("000");
    }

    void GenerateAlvo()
    {
        float rndx = Random.Range(-screenWidth, screenWidth);
        float rndy = Random.Range(-screenHeigh, screenHeigh);

        var newPos = new Vector2(rndx, rndy);
        var newAlvo = Instantiate(alvo, newPos, Quaternion.identity);

        existingAlvos.Enqueue(newAlvo);
    }
}
