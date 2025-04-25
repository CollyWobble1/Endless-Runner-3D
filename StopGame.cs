using Unity.VisualScripting;
using UnityEngine;

public class StopGame : MonoBehaviour
{
    public Obstacles obstaclesSc;
    public MoveRoads moveRoadsSc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (obstaclesSc != null)
        {
            Debug.Log("Shit do be working");
            if (obstaclesSc.isDestroyed == true)
            {
                moveRoadsSc.roadSpeed = 0;
            }

        }
        
    }
}
