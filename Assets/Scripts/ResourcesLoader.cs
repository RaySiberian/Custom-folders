using System;
using UnityEngine;

public class ResourcesLoader : MonoBehaviour
{
    [SerializeField] private SpriteRenderer baseSprite;
    [SerializeField] private Transform prefabRoot;

    [SerializeField] private string[] icon = new string[2];
    private GameObject obj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetupIcon(icon[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetupIcon(icon[1]);
        }
    }

    private void SetupIcon(string configName)
    {
        var config = Resources.Load<IconInfo>($"Configs/{configName}");
        var sprite = Resources.Load<Sprite>($"Icons/{config.IconName}");
        var prefab = Resources.Load<GameObject>($"Prefabs/{config.PrefabName}");

        baseSprite.sprite = sprite;
        if (obj != null)
        {
            Destroy(obj);
        }

        obj = Instantiate(prefab, prefabRoot);
    }
}