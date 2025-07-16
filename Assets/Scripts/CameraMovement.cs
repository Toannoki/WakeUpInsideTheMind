using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    // Các tham số mới để giới hạn góc xoay ngang
    public float minYawAngle = -360f; // Góc xoay ngang tối thiểu
    public float maxYawAngle = 360f;  // Góc xoay ngang tối đa

    // xRotation sẽ giữ nguyên giá trị ban đầu, không thay đổi
    // float xRotation = 0f; 
    float yRotation = 0f; // Góc xoay ngang hiện tại

    void Start()
    {
        // Khóa con trỏ chuột vào giữa màn hình và ẩn đi
        Cursor.lockState = CursorLockMode.Locked;
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 100f) * 100;
    }

    void Update()
    {
        // Lấy giá trị di chuyển chuột theo trục X (ngang)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // Giá trị mouseY được tính nhưng không được sử dụng để xoay dọc nữa
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; 

        // -- Bỏ qua phần cập nhật xoay dọc --
        // xRotation -= mouseY;
        // xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Cập nhật góc xoay ngang
        yRotation += mouseX; // Thêm giá trị mouseX vào góc xoay ngang

        // Giới hạn góc xoay ngang trong khoảng đã định
        yRotation = Mathf.Clamp(yRotation, minYawAngle, maxYawAngle);

        // Áp dụng xoay cho camera.
        // xRotation được giữ nguyên (mặc định là 0f nếu không thay đổi),
        // chỉ có yRotation (xoay ngang) được áp dụng.
        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
