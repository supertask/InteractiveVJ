using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using System.IO;

public class TexSaver : MonoBehaviour
{
    public Texture2D tex;
    public string texFilename = "font.png";

    void Start()
    {
        var png = tex.EncodeToPNG();
        string path = Application.persistentDataPath;
        path = Application.dataPath + "/Plugins/TexRenderer/" + texFilename;
        Debug.Log(path);
        File.WriteAllBytes( path, png );
    }

}
