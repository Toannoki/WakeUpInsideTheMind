using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public SetingsMenu SettingMenu;
    private string disable_object = "First_Timeline";
    private string enable_object = "Ending_TimeLine";
    private bool shouldHandleObjects = false;
    public void LoadSceneSimple(string sceneName)
    {
        Load_Scene(sceneName, false);
    }

    public void LoadSceneWithObjects(string sceneName)
    {
        Load_Scene(sceneName, true);
    }
    public void Load_Scene(string sceneName, bool handleObjects = false)
    {
        Debug.Log("Đang load scene: " + sceneName);
        shouldHandleObjects = handleObjects;

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);
    }
    void Update()
    {
        if (SettingMenu != null)
            if (Input.GetKeyDown(KeyCode.Escape))
                if (SettingMenu.gameObject.activeSelf)
                    SettingMenu.BackToGame();
                else
                    SettingMenu.Pause();      
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene đã load xong: " + scene.name);

        if (shouldHandleObjects)
        {
            GameObject toDisable = FindEvenIfInactive(disable_object);
            if (toDisable != null)
            {
                toDisable.SetActive(false);
                Debug.Log("Đã tắt object: " + disable_object);
            }
            else
            {
                Debug.LogWarning("Không tìm thấy object để tắt: " + disable_object);
            }

            GameObject toEnable = FindEvenIfInactive(enable_object);
            if (toEnable != null)
            {
                toEnable.SetActive(true);
                Debug.Log("Đã bật object: " + enable_object);
            }
            else
            {
                Debug.LogWarning("Không tìm thấy object để bật: " + enable_object);
            }
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private GameObject FindEvenIfInactive(string objectName)
    {
        Transform[] allObjects = GameObject.FindObjectsOfType<Transform>(true); // true để tìm cả inactive
        foreach (Transform t in allObjects)
        {
            if (t.name == objectName)
            {
                return t.gameObject;
            }
        }
        return null;
    }
}
