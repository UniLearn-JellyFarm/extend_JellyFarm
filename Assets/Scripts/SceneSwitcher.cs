using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string mainScene = "SampleScene";
    public string secondaryScene = "Scene1";

    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void SwitchToSecondaryScene()
    {
        SceneManager.LoadScene(secondaryScene);
    }

    private void Update()
    {
        // ESC Ű�� ������ ���� ���� "Scene1"�� �� "SampleScene"���� ��ȯ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == secondaryScene)
            {
                SceneManager.LoadScene(mainScene);
            }
        }
    }
}