using UnityEngine;

public class NewWallSections : MonoBehaviour
{
    [SerializeField] GameObject roads;
    [SerializeField] Vector3 newRoadsPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("WallTrigger"))
            {
            Instantiate(roads, newRoadsPos, Quaternion.identity);
            Debug.Log(transform.position + " Shit is working ");
        }
    }
}
