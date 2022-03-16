using System.IO;
using UnityEngine;

public class Test : MonoBehaviour
{
   [SerializeField] private Renderer hairRenderer;
   [SerializeField] private Renderer torsoRenderer;
    void Start()
    {
        byte[] bytes;
        Texture2D texture2D = null;
        
        var directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        var allFiles = directoryInfo.GetFiles("*.*");
        foreach (var fileInfo in allFiles)
        {
            if (fileInfo.Name.Contains("meta"))
            {
                continue;
            }
            bytes = File.ReadAllBytes(fileInfo.FullName);
           
            texture2D = new Texture2D(1, 1);
            texture2D.LoadImage(bytes);
            hairRenderer.material.mainTexture = texture2D;
            //SaveTexture(texture2D);
        }
    }

    
#if UNITY_EDITOR
    [ContextMenu("Save")]
    private void SaveTexture(Texture2D texture2D)
    {
        var bytes = texture2D.EncodeToPNG();
        var path = Path.Combine(Application.dataPath, "Textures");
        path = Path.Combine(path, "test.png");
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? string.Empty);
        }
        File.WriteAllBytes(path,bytes);
    }
#endif
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
