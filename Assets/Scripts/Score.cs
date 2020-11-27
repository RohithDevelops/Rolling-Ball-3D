using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Transform playerPos;

    void Update()
    {
        scoreText.text = (playerPos.position.z-2).ToString("0");
    }
}
