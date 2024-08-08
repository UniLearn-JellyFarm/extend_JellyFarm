using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitOnEsc : MonoBehaviour
{
    private string mainScene = "SampleScene";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(mainScene);
        }
    }
}
