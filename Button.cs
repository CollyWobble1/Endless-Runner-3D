using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Button : MonoBehaviour
{
    public Button toMainSceneButton;
    void Start()
    {

   }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void ButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
