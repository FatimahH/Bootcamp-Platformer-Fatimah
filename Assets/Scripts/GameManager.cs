using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;

    [SerializeField] private int collectibles;
    [SerializeField] private TextMeshProUGUI collectiblesText;

    private void Start()
    {
        isGameOver = false;
    }

    public void AddCollectible()
    {
        collectibles++;
        collectiblesText.text = "" + collectibles;
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

}
