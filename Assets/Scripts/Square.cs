using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 랜덤 위치 설정
        float x = Random.Range(-3.0f, 3.0f);
        float y = Random.Range(3.0f, 5.0f);

        transform.position = new Vector2(x, y);

        // 랜덤 사이즈 설정
        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector2(size, size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
