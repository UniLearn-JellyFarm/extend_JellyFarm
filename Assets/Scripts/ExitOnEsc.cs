using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitOnEsc : MonoBehaviour
{
    private string mainScene = "SampleScene";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ScoreManager�� ������ �����ϴ� �޼��� ȣ��
            ScoreManager.instance.SaveScore();

            // SampleScene���� ��ȯ
            SceneManager.LoadScene(mainScene);
        }
    }
}
