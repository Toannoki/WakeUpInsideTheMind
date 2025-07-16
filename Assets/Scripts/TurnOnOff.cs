using TMPro;
using UnityEngine;
using System.Collections;

public class TurnOnOff : MonoBehaviour
{
    public GameObject Object;
    public string[] Dialog;
    public TextMeshProUGUI thoai;
    public TextMeshProUGUI nguoinoi;

    private int currentDialogIndex = 0;
    private Coroutine typingCoroutine;
    private bool isTyping = false;
    private string currentText = "";

    public float typingSpeed = 0.1f;
    public AudioSource audioSource;   // thời gian chờ giữa mỗi chữ cái

    public void TurnOn(GameObject game =null)
    {
        if (game != null)
             audioSource = game.GetComponent<AudioSource>() ;
        Object.SetActive(true); // Kích hoạt đối tượng trước
        currentDialogIndex = 0;
        DisplayCurrentDialog(); // Sau khi đã active
    }

    public void TurnOff()
    {
        Object.SetActive(false);
    }

    public void NextDialog()
    {
        if (isTyping)
        {
            // Nếu đang đánh máy, nhấn sẽ hiển thị toàn bộ ngay lập tức
            StopCoroutine(typingCoroutine);
            thoai.text = currentText;
            isTyping = false;
            if (audioSource != null)
                audioSource.Stop();
        }
        else
        {
            currentDialogIndex += 2;
            if (currentDialogIndex < Dialog.Length)
            {
                DisplayCurrentDialog();
            }
            else
            {
                TurnOff();
            }
        }
    }

    private void DisplayCurrentDialog()
    {
        if (Dialog.Length >= currentDialogIndex + 2)
        {
            string dialogKey = Dialog[currentDialogIndex];
            string speakerKey = Dialog[currentDialogIndex + 1];

            string dialogText = LanguageManager.Instance.GetText(dialogKey);
            string speakerText = LanguageManager.Instance.GetText(speakerKey);

            nguoinoi.text = speakerText;

            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            typingCoroutine = StartCoroutine(TypeText(dialogText));
        }
        else
        {
            Debug.LogWarning("Không đủ cặp thoại và người nói tại chỉ mục " + currentDialogIndex);
            TurnOff();
        }
    }

    IEnumerator TypeText(string textToType)
    {
        isTyping = true;
        currentText = textToType;
        thoai.text = "";

        // ✅ Phát âm thanh bàn phím một lần
        if (audioSource != null)
        {
            audioSource.Play();
        }

        foreach (char letter in textToType)
        {
            thoai.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // ⏹ Dừng âm thanh khi kết thúc đánh máy
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        isTyping = false;
    }


    void Update()
    {
        if (Object.activeSelf && Input.GetMouseButtonDown(0))
        {
            NextDialog();
        }
    }
}
