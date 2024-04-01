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
    public Text bestScore;

    public Animator anim; // 애니메이션에 접근하기 위한 Animator타입의 변수

    bool isPlay = true; // 타임의 소수점값이 미세하게 달라지는 것마저 방지하기 위한 변수 선언

    float time = 0.0f;

    string key = "bestScore"; // 오타방지

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
        Time.timeScale = 1.0f;

        // 반복 실행 함수
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay) // 게임 플레이시에만(조금 더 정확한 타임값 도출 가능)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2"); // 소수점 두 번째자리까지
        }
    }

    void MakeSquare()
    {
        // 프리팹 생성
        Instantiate(square);
    }

    public void GameOver()
    {
        isPlay = false;
        
        Time.timeScale = 0.0f; // 타임의 크기 = 0 -> 멈춘것과 같음
        nowScore.text = time.ToString("N2");

        // 최고 점수가 있다면
        if (PlayerPrefs.HasKey(key))
        {
            // 최고 점수 가져오기
            float best = PlayerPrefs.GetFloat(key);
            // 최고 점수 < 현재 점수
            if(best < time)
            {
                // 현재 점수를 최고 점수에 저장한다.
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("N2"); // 현재 점수가 최고 점수이니까 time 값을 넣어도 됨
            }
            else // 최고 점수 > 현재 점수
            {
                bestScore.text = best.ToString("N2"); // best가 여전히 최고 점수니까
            }
        }
        else // 최고 점수가 없다면
        {
            // 현재 점수를 저장한다.
            PlayerPrefs.SetFloat(key, time);
            bestScore.text = time.ToString("N2");
        }        

        endPanel.SetActive(true);
    }
}
