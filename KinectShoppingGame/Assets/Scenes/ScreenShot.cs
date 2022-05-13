using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public static ScreenShot Instance;
    public bool IsScreenShotTaken;
    
    public Camera camera;

   
    private void Start()
    {
        Instance = this;
        IsScreenShotTaken = false;
        //TakeScreenShot();
        
    }
    
    // Take a "screenshot" of a camera's Render Texture.
 public   void TakeScreenShot()
    {
        // The Render Texture in RenderTexture.active is the one
        // that will be read by ReadPixels.
        var currentRT = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;

        // Render the camera's view.
        camera.Render();

        // Make a new texture and read the active Render Texture into it.
        Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        image.Apply();

        // Replace the original active Render Texture.
        RenderTexture.active = currentRT;
        string path = Application.dataPath + "/" + savePath + fileName;
        saveTexture(path, image);
        
    }


    public string savePath = "StreamingAssets/";
    //File name
    public string fileName = "cameraCapture.png";
    public  void saveTexture(string path, Texture2D texture) {
        string directory = Application.dataPath + "/WinnersImages/";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        var imagename = "Oberoi" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+".png";
        path = directory + imagename;
        File.WriteAllBytes(path, texture.EncodeToPNG());
        IsScreenShotTaken = true;
        #region PrintWithWindow


        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        process.StartInfo.UseShellExecute = true;
        process.StartInfo.FileName = path;
        process.StartInfo.Verb = "print";

        process.Start();


        #endregion
        
#if UNITY_EDITOR
        Debug.Log ("saved screenshot to:" + path);
#endif
    }
}
