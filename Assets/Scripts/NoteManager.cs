using UnityEngine;
using TMPro;

public class NoteManager : MonoBehaviour
{
    public TextMeshProUGUI noteText; // Gắn từ Inspector
    private int currentPage = 0;
    public GameObject Paper;
    public GameObject RightMouse;
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            noteText.text = "";
            Paper.SetActive(false);
            RightMouse.SetActive(false);
        }        
    }
   public void ShowPage(int pageIndex)
    {
        if (pageIndex == 0)
            noteText.text = LanguageManager.Instance.GetText("Page_1");
        if (pageIndex == 1)
            noteText.text = LanguageManager.Instance.GetText("Page_2"); 
        if (pageIndex == 2)
            noteText.text = LanguageManager.Instance.GetText("Page_3");
        if (pageIndex == 3)
            noteText.text = LanguageManager.Instance.GetText("Page_4");
        if (pageIndex == 4)
            noteText.text = LanguageManager.Instance.GetText("Page_5");
    }
}
