using UnityEngine;
using System.Collections;

public class JumpScare : MonoBehaviour
{
    public AudioClip scareSound;         // Kéo thả âm thanh vào
    public float volume = 1f;
    public float hideDelay = 0.5f;       // Thời gian hiển thị trước khi ẩn

    public GameObject soundPlayerPrefab; // Prefab có AudioSource (rỗng hoặc chứa sẵn)

    public void JumpAndHide()
    {
        gameObject.SetActive(true);

        // Phát âm thanh bằng object tách biệt
        GameObject soundPlayer = Instantiate(soundPlayerPrefab);
        AudioSource tempSource = soundPlayer.GetComponent<AudioSource>();

        if (tempSource == null)
        {
            tempSource = soundPlayer.AddComponent<AudioSource>();
        }

        tempSource.clip = scareSound;
        tempSource.volume = volume;
        tempSource.Play();

        // Hủy sound player sau khi âm thanh kết thúc
        Destroy(soundPlayer, scareSound.length);

        // Bắt đầu coroutine để ẩn object sau thời gian delay
        StartCoroutine(HideAfterDelay());
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(hideDelay);
        gameObject.SetActive(false);
    }
}
