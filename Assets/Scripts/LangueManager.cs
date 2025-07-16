using System.Collections.Generic;
using UnityEngine;

public enum Language
{
    English,
    Vietnamese
}

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance { get; private set; }

    public Language currentLanguage = Language.Vietnamese;

    private Dictionary<string, string> vietnamese = new Dictionary<string, string>()
    {
        { "0", "An" },
        { "3", "Ủa...? Biến đâu mất rồi?" },
        { "4", "Chắc mình còn ngái ngủ quá..." },
        { "5", "Thôi đi tìm tiếp vậy..." },
        { "6", "Lại nữa hả...?" },
        { "7", "Mình sắp phát điên mất..." },
        { "8", "Thì ra nó vẫn ở đây..." },
        { "9", "Ủa... Gấu Teddy của mình đâu rồi?" },
        { "10", "Không lẽ mình làm rơi ở đâu rồi ta?" },
        { "11", "Ơ... vẫn còn cầm Teddy..." },
        { "16", "Ủa? Sao cửa bị kẹt vậy nè..." },

        { "18", "Mình đang ở đâu đây" },
        { "19", "Ơ... Vẫn là phòng của mình nhưng sao ..." },
        { "20", "...nó cũ kỹ như vậy" },
        { "21", "Mẹ ơi! Ba ơi (La lớn)" },
        { "22", "Ba lại đánh mẹ nữa à" },
        { "24", "Mình phải tìm cách cứu mẹ thôi" },
        { "25", "Mẹ... !" },
        { "26", "Vừa nãy là ... !" },
        { "27", "Hình như mình có thể dùng Teddy để mở cửa!" },
        { "28", "Cửa khóa rồi" },
        { "29", "Hình như mẹ nói chìa khóa phòng này ở trong cái rương" },


        { "1", "Ba" },
        { "14", "Từ từ! Tao đang vô!" },
        { "15", "Đói thì ăn trước đi!" },

        { "2", "Mẹ" },
        { "12", "Con phụ mẹ dọn đồ ăn lên bàn nha." },
        { "13", "Ra gọi ba vô ăn cơm đi con." },
        { "17", "Để mẹ mở cửa cho." },
        { "23", "Mẹ không sao ...  con phải th..." },


        { "Door_1", "Mình chưa tìm được Teddy :((" },

        { "Play", "Thức" },
        { "Settings", "Tiềm thức" },
        { "Exit", "Buông" },
        { "Exit1", "Rời" },
        { "Continue", "Níu" },
        { "Resolution", "Độ phân giải" },
        { "Sensitivity", "Độ nhạy" },
        { "Language", "Ngôn ngữ" },


        { "Page_1", " \"Ngày 20 tháng 10 năm 1995\\n\\nHôm nay mẹ đã cưới người mà mẹ " +
            "từng nghĩ sẽ nắm tay đi hết cả cuộc đời. Mẹ cười suốt cả buổi sáng, đến mức " +
            "má đau nhói mà vẫn không muốn ngừng. Ba con lóng ngóng buộc nơ giày cho mẹ, tay run run. " +
            "Lúc ấy mẹ nghĩ, nếu có thể giữ được khoảnh khắc này mãi, thì thật tốt biết bao.\\n\\nCon số mẹ thầm ghi nhớ hôm nay là **7**" +
            " – số bàn tiệc nhỏ mà ba mẹ ngồi cùng nhau, giữa những tiếng chúc mừng rộn rã. Hy vọng con sẽ nhớ, " +
            "mẹ từng rất hạnh phúc khi bắt đầu cuộc hành trình này.\"," },
        { "Page_2", "Ngày 12 tháng 11 năm 1998\n\nCon yêu của mẹ, hôm nay con đến với thế giới này. Mẹ đã khóc" +
            " – không phải vì đau, mà vì lần đầu được nghe tiếng khóc của con. Mọi đau đớn tan biến khi mẹ thấy " +
            "đôi bàn tay nhỏ xíu ấy nắm lấy ngón tay mẹ.\n\nNhưng ba con không có mặt. Ông nói đang bận công trình. " +
            "Mẹ thấy buồn, một chút thất vọng... nhưng không dám oán trách. Mẹ chỉ mong sau này con lớn lên đủ đầy " +
            "hơn mẹ bây giờ.\n\nMẹ đã thì thầm vào tai con con số **3**, như một điều bí mật riêng giữa mẹ và con – " +
            "vì con là phép màu thứ ba trong đời mẹ: sau tình yêu, hôn nhân... là con." },
        { "Page_3","Ngày 9 tháng 4 năm 2006\n\nTối nay ba con lại về trong men rượu. Cánh" +
            " cửa bật mở, tiếng chai lọ va vào nhau, mùi rượu nồng nặc xộc vào phòng khách. " +
            "Con đang học bài, còn mẹ thì đứng chắn trước mặt ba. Rồi cái tát giáng xuống mặt mẹ, " +
            "và một tiếng đập thật lớn làm con bật khóc.\n\nMẹ chỉ biết ôm con, tay che lấy đầu con," +
            " thì thầm \"không sao đâu\" mà nước mắt mẹ rơi mãi. Mẹ tủi thân lắm. Mẹ đã cố gắng," +
            " thật sự cố gắng, nhưng mẹ bất lực.\n\nHôm nay mẹ ghi lại con số **1** – không phải vì" +
            " đây là lần đầu, mà vì đây là lần đầu tiên mẹ thấy mình không thể bảo vệ được con. " +
            "Mẹ xin lỗi, con yêu."},
        { "Page_4","Ngày 14 tháng 2 năm 2007\n\nValentine. Nhưng mẹ không tặng hoa, " +
            "không nhận quà. Mẹ chỉ mang một tập giấy tờ đến tòa án và ký vào đơn ly hôn." +
            " Không còn nước mắt, chỉ còn im lặng và bàn tay lạnh ngắt.\n\nMẹ đã chọn kết " +
            "thúc – không vì hết yêu, mà vì mẹ không thể để con lớn lên trong sợ hãi. Mẹ cần" +
            " giải thoát cho cả hai mẹ con khỏi bóng tối kéo dài suốt những năm qua.\n\nHôm nay" +
            ", mẹ ghi lại con số **0**. Từ giờ, sẽ không còn một tiếng la mắng, một vết tím, " +
            "một đêm trằn trọc vì sợ. Từ con số 0 này, mẹ và con sẽ bắt đầu lại. Bình yên hơn." +
            " Can đảm hơn.\n\nThương con, mãi mãi."
        },
        { "Page_5","Tao xin lỗi ! Tao chỉ muốn tất cả im lặng thôi!"},

        { "Credit_1", "Một dự án cá nhân bởi: TnK" },
        { "Credit_2", "Lập trình & Thiết kế trò chơi: TnK\r\nThiết kế màn chơi: TnK\r\nBiên kịch & Cốt truyện: TnK" },
        { "Credit_3", "Âm nhạc:\r\nĐược tạo bằng Suno AI\r\n(https://suno.com)\r\n\r\nEngine:\r\nPhát triển bằng Unity" },
        { "Credit_4", "Lời cảm ơn:\r\n- Cộng đồng Unity\r\n- Các nhà sáng tạo tài nguyên miễn phí\r\n- Công cụ AI hỗ trợ dự án" },

        { "Question", "Mẹ\r\nNếu quay lại khoảnh khắc đó, con có muốn trả thù ba không ?" },
        { "No_choice", "Mẹ\r\nCon đã làm điều mà ba con không làm được – buông bỏ." },
        { "Yes_choice", "Bạo lực được sinh ra từ thù hận. Và thù hận… sẽ luôn quay lại từ đầu" },
        { "Yes", "Dạ có " },
        { "No", "Dạ không" },
        { "SwitchBack", "Trở lại" },

    };

    private Dictionary<string, string> english = new Dictionary<string, string>()
{
    { "0", "An" },
    { "3", "Huh? Where did it go?" },
    { "4", "Maybe I'm still sleepy..." },
    { "5", "I better keep looking..." },
    { "6", "Again...? Really...?" },
    { "7", "Am I going crazy...?" },
    { "8", "Oh... It was here all along." },
    { "9", "Wait—where's my Teddy?" },
    { "10", "Did I drop it somewhere?" },
    { "11", "No... I'm still holding Teddy." },
    { "16", "Why's the door stuck...?" },


    { "18", "Where... where am I?" },
    { "19", "Huh... It’s still my room, but why does it..." },
    { "20", "...look so old?" },
    { "21", "Mom! Dad! (yelling)" },
    { "22", "Is Dad hurting Mom again?" },
    { "24", "I have to find a way to help Mom!" },
    { "25", "Mom...!" },
    { "26", "That just now was...!" },
    { "27", "I think... maybe I can use Teddy to open the door!" },
    { "28", "The door’s locked!" },
    { "29", "I think Mom said the key is inside that chest!" },

    { "1", "Dad" },
    { "14", "Wait. I'm coming." },
    { "15", "If you're hungry, then eat." },

    { "2", "Mom" },
    { "12", "Sweetie, help mommy set the table." },
    { "13", "Go call daddy in for dinner, okay?" },
    { "17", "Let me open that for you." },
    { "23", "Mom’s okay... y-you must wa—..." },

    { "Door_1", "I haven’t found Teddy yet :((" },

    { "Play", "Awaken" },
    { "Settings", "Subconscious" },
    { "Exit", "Leave" },
    { "Exit1", "Exit" },
    { "Continue", "Cling" },
    { "Resolution", "Resolutions" },
    { "Sensitivity", "Sensitivity" },
    { "Language", "Language" },

    { "Page_1", "\"October 20, 1995\n\nToday, I married the man I once believed I would hold hands with for the rest of my life. I smiled all morning, so much that my cheeks ached, yet I didn’t want to stop. Your father clumsily tied my shoelaces, his hands trembling. At that moment, I thought, if only I could hold onto this moment forever, how wonderful it would be.\n\nThe number I secretly remembered today is **7** – the number of the small table where your father and I sat together, surrounded by joyful congratulations. I hope you remember, I was truly happy when I began this journey.\"" },

    { "Page_2", "November 12, 1998\n\nMy beloved child, today you came into this world. I cried – not from pain, but because I heard your cry for the first time. All the pain vanished when I saw your tiny hand grasp my finger.\n\nBut your father wasn’t there. He said he was busy with a construction project. I felt sad, a bit disappointed… but I didn’t dare blame him. I only hoped that one day you would grow up with more than I ever had.\n\nI whispered into your ear the number **3**, like a secret shared just between us – because you are the third miracle of my life: after love, after marriage… came you." },

    { "Page_3", "April 9, 2006\n\nTonight, your father came home drunk again. The door slammed open, the sound of bottles clinking, the stench of alcohol filled the living room. You were doing your homework, and I stood in front of him. Then came the slap across my face, and a loud bang that made you burst into tears.\n\nI could only hold you, shielding your head with my hands, whispering \"It’s okay\" as my tears kept falling. I felt so alone. I tried, I truly tried, but I was powerless.\n\nToday I recorded the number **1** – not because it was the first time, but because it was the first time I realized I couldn't protect you. I’m sorry, my love." },

    { "Page_4", "February 14, 2007\n\nValentine’s Day. But there were no flowers, no gifts. I simply brought a stack of papers to the courthouse and signed the divorce papers. No more tears, just silence and a cold hand.\n\nI chose to end it – not because I stopped loving, but because I couldn’t let you grow up in fear. I needed to free us both from the darkness that had stretched on for years.\n\nToday, I wrote down the number **0**. From now on, there will be no more yelling, no more bruises, no more sleepless nights from fear. From this zero, you and I will start over. More peacefully. More bravely.\n\nLove you, always." },

    { "Page_5", "I'm sorry! I just wanted everything to be quiet!" },

    {"Credit_1","A solo project by: TnK  " },
    {"Credit_2","Programming & Game Design: TnK\r\nLevel Design: TnK\r\nWriting & Story: TnK" },
    {"Credit_3","Music:\r\nGenerated using Suno AI  \r\n(https://suno.com)\r\n\r\nEngine:\r\nMade with Unity" },
    {"Credit_4","Special Thanks:\r\n- Unity Community\r\n- The creators of free 3D assets\r\n- AI tools that made this possible" },

    { "Question", "Mom\r\nIf you could go back to that moment, would you want to take revenge on your father?" },
    { "No_choice", "Mom\r\nYou did what your father couldn't – let go." },
    { "Yes_choice", "Violence is born from hatred. And hatred… will always come back around." },
    { "Yes", "Yes, I would" },
    { "No", "No, I wouldn't" },
    { "SwitchBack", "Go back" },
};


    private void Awake()
    {
        // Đảm bảo Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Không bị huỷ khi đổi scene
    }

    /// <summary>
    /// Trả về bản dịch tương ứng theo ngôn ngữ hiện tại.
    /// Nếu không có key, trả về chính key đó và cảnh báo.
    /// </summary>
    public string GetText(string key)
    {
        Dictionary<string, string> dict = currentLanguage == Language.Vietnamese ? vietnamese : english;

        if (dict.TryGetValue(key, out string value))
            return value;

        Debug.LogWarning("Thiếu bản dịch cho key: " + key);
        return key;
    }

    /// <summary>
    /// Đổi ngôn ngữ trong lúc chạy game.
    /// </summary>
    public delegate void OnLanguageChanged();
    public event OnLanguageChanged LanguageChanged;

    public void SetLanguage(Language lang)
    {
        if (currentLanguage == lang) return;

        currentLanguage = lang;
        Debug.Log("Đã đổi ngôn ngữ sang: " + lang);

        // Gọi sự kiện để mọi UI biết và cập nhật
        LanguageChanged?.Invoke();
    }



}
