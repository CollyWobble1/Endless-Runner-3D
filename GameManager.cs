using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void AddScore(int value)
    {
        score += value;
        UIManager.instance.UpdateScore(score);
        // Increase speed every 10 coins
       
    }

}
