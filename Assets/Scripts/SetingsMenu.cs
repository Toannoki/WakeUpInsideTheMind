using StarterAssets;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static LanguageManager;

public class SetingsMenu : MonoBehaviour
{
    public Slider sensitivitySlider;
    public FirstPersonController firstPersonController;
    public TMP_Dropdown languageDropdown;

    void Start()
    {
        // --- Cài đặt Language ---
        languageDropdown.ClearOptions();
        languageDropdown.AddOptions(new List<string> { "English", "Tiếng Việt" });

        languageDropdown.value = (int)LanguageManager.Instance.currentLanguage;
        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);

        // --- Cài đặt thanh trượt sensitivity ---
        float savedSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 1.0f);
        sensitivitySlider.value = savedSensitivity;
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
    }

    public void OnSensitivityChanged(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", value);
        PlayerPrefs.Save();
    }

    public void ExitGame()
    {
        Debug.Log("Thoát Game");
        Application.Quit();
    }

    public void BackToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.SetActive(false);
        if (firstPersonController != null)
            firstPersonController.ActivateRotation(true);
        firstPersonController.RotationSpeed = PlayerPrefs.GetFloat("MouseSensitivity", 1.0f);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        if (firstPersonController != null)
            firstPersonController.ActivateRotation(false);
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    void OnDestroy()
    {
        languageDropdown.onValueChanged.RemoveListener(OnLanguageChanged);
    }

    private void OnLanguageChanged(int index)
    {
        Language selectedLang = (Language)index;
        LanguageManager.Instance.SetLanguage(selectedLang);
    }
}
