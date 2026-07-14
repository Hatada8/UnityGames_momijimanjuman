using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    void Start()
    {
        int count = GiftCount.Instance.giftCount;

        string rank;
        string comment;

        if (count >= 8)
        {
            rank = "1軍";
            comment = "みんなにもみじまんじゅうを配る姿はまさに陽キャ";
        }
        else if (count >= 6)
        {
            rank = "TierA";
            comment = "もみじまんじゅまんとならもっと高みをめざせるね。";
        }
        else if (count >= 3)
        {
            rank = "右翼";
            comment = "投票には行こうね。";
        }
        else
        {
            rank = "O型";
            comment = "大雑把な性格ですね。";
        }

        resultText.text = "診断結果：" + rank + "\n" + comment;
    }
}