using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject square;
    public GameObject endPanel;
    public Text timeTxt;
    public Text nowScore;

    float time = 0.0f;

    private void Awake()
    {
        if(Instance == null) // Instance가 비어있을 때만
        {
            Instance = this;
        }     
    }

    // Start is called before the first frame update
    void Start()
    {
        // 반복 실행 함수
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2"); // 소수점 두 번째자리까지
    }

    void MakeSquare()
    {
        // 프리팹 생성
        Instantiate(square);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f; // 타임의 크기 = 0 -> 멈춘것과 같음
        nowScore.text = time.ToString("N2");
        endPanel.SetActive(true);
    }
}
