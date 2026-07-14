using UnityEngine;
using UnityEngine.SceneManagement;

public class OnMouseDown_SwitchScene : MonoBehaviour
{
    public string sceneName;

    void OnMouseDown()
    {
        Debug.Log("押された！");
        SceneManager.LoadScene(sceneName);
    }
}