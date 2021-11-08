using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotCert : MonoBehaviour
{
    [SerializeField] private RectTransform targetRect;

    private Camera _camera;
    public Text savedText;

    private void Start()
    {
        _camera = Camera.main;
    }
    public void CopyToClipboard(string s)
    {
        TextEditor te = new TextEditor();
        te.text = s;
        te.SelectAll();
        te.Copy();
    }

    //Calling the method]

    public void TakeScreenshot(string fileName)
    {
        StartCoroutine(CutSpriteFromScreen(fileName));
    }

    private IEnumerator CutSpriteFromScreen(string fileName)
    {
        yield return new WaitForEndOfFrame();
        var corners = new Vector3[4];
        targetRect.GetWorldCorners(corners);
        //var bl = RectTransformUtility.WorldToScreenPoint(_camera, corners[0]);
        //var tl = RectTransformUtility.WorldToScreenPoint(_camera, corners[1]);
        //var tr = RectTransformUtility.WorldToScreenPoint(_camera, corners[2]);
        var startY = 50;
        var startX = 150;
        var height = 800;
        var width = 1300;
        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        //Texture2D tex = new Texture2D((int)width, (int)height, TextureFormat.RGB24, false);
        Rect rex = new Rect(startX, startY, width, height);
        tex.ReadPixels(rex, 0, 0);
        tex.Apply();
        var bytes = tex.EncodeToPNG();
        Destroy(tex);

        
        //File.WriteAllBytes(Application.dataPath + fileName, bytes);
        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/YourCertificate.png", bytes);
        savedText.text ="File saved into your computer! Paste the text in your clipboard now into your file explorer and you will see your certificate.";
        CopyToClipboard("C:\\Users\\<your pc name>\\AppData\\LocalLow\\dip2021\\E057");

    }

    //Attach this script to a GameObject
//This script outputs the Application’s path to the Console
//Run this on the target device to find the application data path for the platform

}
