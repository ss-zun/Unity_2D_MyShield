using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject square;

    // Start is called before the first frame update
    void Start()
    {
        // 반복 실행 함수
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeSquare()
    {
        // 프리팹 생성
        Instantiate(square);
    }
}
