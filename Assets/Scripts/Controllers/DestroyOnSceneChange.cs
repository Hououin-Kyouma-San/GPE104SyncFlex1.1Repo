using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnSceneChange : MonoBehaviour
{
    private void Awake() => DontDestroyOnLoad(gameObject);
    private void OnEnable() => SceneManager.activeSceneChanged += SceneChanged;
    private void OnDisable() => SceneManager.activeSceneChanged -= SceneChanged;

    private void SceneChanged(Scene oldScene, Scene newScene)
    {
        if (oldScene.buildIndex != newScene.buildIndex) Destroy(gameObject);
    }
}