using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;

public class WebGlVideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage rawImage;
    public string videoFileName = "momijimanjuman_title.mp4"; // そのままでOKです

    void Start()
    {
        // 1. 実行環境に合わせて動画のパスを自動調整
        string videoPath = Path.Combine(Application.streamingAssetsPath, videoFileName);
        videoPlayer.url = videoPath;

        // 2. 動画の準備が完了した時の処理
        videoPlayer.prepareCompleted += (vp) => {
            rawImage.texture = vp.texture;
            vp.Play(); // ★ここに「再生を開始する」処理を追加しました！
        };

        // 動画の準備を開始
        videoPlayer.Prepare();
    }
}