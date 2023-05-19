using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 1000;
    private Text _gt;
    void Awake() { //a
// Если значение HighScore уже существует в PlayerPrefs, прочитать его
        if (PlayerPrefs.HasKey("HighScore")) { // b
            score = PlayerPrefs.GetInt("HighScore");
        }
// Сохранить высшее достижение HighScore в хранилище
        PlayerPrefs.SetInt("HighScore", score); // c
    }
    void Start()
    {
        _gt = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _gt.text = "High Score: "+score;
        if (score > PlayerPrefs.GetInt("HighScore")) { // d
            PlayerPrefs.SetInt("HighScore", score);
        }

    }
}
