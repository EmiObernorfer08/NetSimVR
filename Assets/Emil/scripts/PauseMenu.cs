using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject crosshairUI;
    public GameObject FPC;

    private FirstPersonLook FPL;
    private float oldSensitivity;

    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        FPL = FPC.GetComponent<FirstPersonLook>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshairUI.SetActive(true);

        FPL.sensitivity = oldSensitivity; 
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshairUI.SetActive(false);

        oldSensitivity = FPL.sensitivity; 
        FPL.sensitivity = 0f;             
    }

    public void Quit()
    {
        Application.Quit();
    }
}
