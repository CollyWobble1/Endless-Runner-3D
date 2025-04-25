using Unity.Cinemachine;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public Vector3 coinRotation = new Vector3(0, 30, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.back * 10f
            * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            Destroy(gameObject);
            Debug.Log("Bitch");
            GameManager.instance.AddScore(1);
        }
    }
}
