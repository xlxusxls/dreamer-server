using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
// using System.Diagnostics; // Stopwatch를 사용하기 위해 추가

public class CameraCapture : MonoBehaviour
{
    public RenderTexture renderTexture; // 캡처한 이미지를 저장할 Render Texture 변수

    void Start()
    {
        
        // renderTexture 변수에 Render Texture를 할당해야 합니다.
        // renderTexture = someRenderTexture;
    }

    public void StartCaptureAndSaveImage()
    {
        StartCoroutine(CaptureAndSaveImage());
    }

    IEnumerator CaptureAndSaveImage()
    {
        yield return new WaitForEndOfFrame();

        // Render Texture 변수에서 이미지 읽어오기
        RenderTexture.active = renderTexture;
        Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        // 읽어온 이미지 JPEG 포맷으로 디코딩
        byte[] bytes = texture2D.EncodeToJPG();

        // Clean up
        RenderTexture.active = null;
        Destroy(texture2D);
    }

    IEnumerator CaptureAndSaveImageElapse()
    {
        yield return new WaitForEndOfFrame();
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch(); // Stopwatch 객체 생성
        stopwatch.Start(); // 알고리즘 실행 시간 측정 시작

        // Render Texture 변수에서 이미지 읽어오기
        RenderTexture.active = renderTexture;
        Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        // 읽어온 이미지 JPEG 포맷으로 디코딩
        byte[] bytes = texture2D.EncodeToJPG();

        stopwatch.Stop(); // 알고리즘 실행 시간 측정 종료
        Debug.Log("Elapsed milliseconds: " + stopwatch.ElapsedMilliseconds); // 실행 시간 출력

        // Clean up
        RenderTexture.active = null;
        Destroy(texture2D);
    }
}
