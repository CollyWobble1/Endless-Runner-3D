using UnityEngine;

public class MoveRoads : MonoBehaviour
{
    public float roadSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * roadSpeed) ;

        if(transform.position.z <= -61)
        {
            Destroy(gameObject);
        }
    }
}
