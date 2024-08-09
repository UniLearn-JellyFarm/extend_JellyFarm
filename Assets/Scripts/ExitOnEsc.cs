using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitOnEsc : MonoBehaviour
{
    private string mainScene = "SampleScene";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ScoreManager의 점수를 저장하는 메서드 호출
            ScoreManager.instance.SaveScore();

            // SampleScene으로 전환
            SceneManager.LoadScene(mainScene);
        }
    }
}
