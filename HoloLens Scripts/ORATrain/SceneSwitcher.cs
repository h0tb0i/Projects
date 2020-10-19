using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoTrainScene()
    {
        SceneManager.LoadScene("Train");
    }

    public void GotoAssemblyScene()
    {
        SceneManager.LoadScene("Assembly");
    }
}
