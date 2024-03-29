using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 스크린상의 마우스 좌표를 카메라가 찍고 있는 월드 좌표로 바꾸기
        // ScreenToWorldPoint() : 스크린의 위치를 게임월드상의 위치로 바꿔주는 함수
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 마우스 위치를 쉴드 위치에 넣기
        transform.position = mousePos;
    }
}
