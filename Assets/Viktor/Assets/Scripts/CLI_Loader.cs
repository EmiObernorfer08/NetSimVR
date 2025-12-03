using UnityEngine;
using UnityEngine.SceneManagement;

public class CLI_Loader : MonoBehaviour
{

    public void LoadNewScene()
    {
        SceneManager.LoadScene("CLI_Scene");
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("ViktorScene");
    }
}
