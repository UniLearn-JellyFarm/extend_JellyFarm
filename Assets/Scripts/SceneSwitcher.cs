using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string mainScene = "SampleScene";
    public string secondaryScene = "Scene1";

    // 버튼 클릭 시 호출되는 함수
    public void SwitchToSecondaryScene()
    {
        SceneManager.LoadScene(secondaryScene);
    }

    private void Update()
    {
        // ESC 키를 누르면 현재 씬이 "Scene1"일 때 "SampleScene"으로 전환
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == secondaryScene)
            {
                SceneManager.LoadScene(mainScene);
            }
        }
    }
}