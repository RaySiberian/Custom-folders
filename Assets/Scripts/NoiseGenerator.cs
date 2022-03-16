using System.IO;
using UnityEditor;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    [SerializeField] private int width = 512;
    [SerializeField] private int height = 512;

    [SerializeField] private float xOrigin;
    [SerializeField] private float yOrigin;

    [SerializeField] private float scale = 10;

    private Texture2D _noiseTexture;
    private Color[] _pix;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _noiseTexture = new Texture2D(width, height);
        _pix = new Color[_noiseTexture.width * _noiseTexture.height];
        _renderer.material.mainTexture = _noiseTexture;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            CalculateNoise();
        }
    }

    private void CalculateNoise()
    {
        var y = 0f;
        while (y < _noiseTexture.height)
        {
            var x = 0f;
            while (x < _noiseTexture.width)
            {
                var xCoord = xOrigin + x / _noiseTexture.width * scale;
                var yCoord = yOrigin + y / _noiseTexture.height * scale;
                var sample = Mathf.PerlinNoise(xCoord, yCoord);

                _pix[(int) y * _noiseTexture.width + (int) x] = new Color(sample, sample, sample);
                x++;
            }

            y++;
        }

        _noiseTexture.SetPixels(_pix);
        _noiseTexture.Apply();
    }
#if UNITY_EDITOR
    [ContextMenu("Save")]
    private void SaveTexture()
    {
        var bytes = _noiseTexture.EncodeToPNG();
        var path = Path.Combine(Application.dataPath, "Textures");
        path = Path.Combine(path, "test.png");
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? string.Empty);
        }
        File.WriteAllBytes(path,bytes);
        AssetDatabase.Refresh();
    }
#endif
}