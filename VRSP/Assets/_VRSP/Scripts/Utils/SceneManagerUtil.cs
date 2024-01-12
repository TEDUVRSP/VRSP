using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerUtil : MonoBehaviour
{
    public void ChangeScene(int targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }

    public void ChangeScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }

    [ContextMenu("MoveToNextScene")]
    public void MoveToNextScene()
    {
        ChangeScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
