using TMPro;
using UnityEngine;

public class Credit : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshProUGUI;
    private bool istextChange = false;
    private void Start()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        if (!istextChange)
            ChangeText();
    }
    private void ChangeText()
    {
        m_TextMeshProUGUI.text = LanguageManager.Instance.GetText(m_TextMeshProUGUI.text);
    }
    public void ChangeText(string text)
    {
        m_TextMeshProUGUI.text = LanguageManager.Instance.GetText(text);
        istextChange = true;
    }
}
