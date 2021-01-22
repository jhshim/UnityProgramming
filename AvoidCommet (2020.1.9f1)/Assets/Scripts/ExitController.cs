using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    public char type;
    public string previousScene;

    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(type == 'p')
                {
                    SceneManager.LoadScene(previousScene);
                }
                else if(type == 'e')
                {
                    Application.Quit();
                }
            }
        }
    }
}
