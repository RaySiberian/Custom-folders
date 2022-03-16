using System;
using UnityEngine;

public class EffectsPlayer : MonoBehaviour
{
    [SerializeField] private EffectButton baseButton;
    private EffectsConfig effectsConfig;

    private void Start()
    {
        effectsConfig = Resources.Load<EffectsConfig>("EffectsConfig");
        var names = effectsConfig.Effects;
        foreach (var name in names)
        {
            var btn = Instantiate(baseButton, baseButton.transform.parent);
            btn.Setup(name,OnEffectsButton);
        }
        baseButton.Setup("Random",OnRandomEffectButton);
    }

    private void OnRandomEffectButton(string id)
    {
        var asset = effectsConfig.GetRandomEffect();
        var obj = Instantiate(asset, Vector3.zero, Quaternion.identity);
        Destroy(obj,5);
    }

    private void OnEffectsButton(string id)
    {
        var asset = effectsConfig.GetEffect(id);
        var obj = Instantiate(asset, Vector3.zero, Quaternion.identity);
        Destroy(obj,5);
    }
}