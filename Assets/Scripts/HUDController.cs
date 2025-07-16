using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;

    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Vector2 defaultSize = new Vector2(32, 32);
    [SerializeField] private Vector2 enlargedSize = new Vector2(64, 64);

    [Header("Extra UI When Enlarged")]
    [SerializeField] private GameObject extraImage; // Gán hình cần hiện ở đây (Image, Icon...)

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCrosshairSize(bool enlarged)
    {
        if (crosshair != null)
        {
            crosshair.sizeDelta = enlarged ? enlargedSize : defaultSize;
        }

        if (extraImage != null)
        {
            extraImage.SetActive(enlarged); // hiện khi crosshair lớn, ẩn khi nhỏ
        }
    }
}
