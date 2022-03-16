using UnityEngine;

public class CharacterConfigurationPanel : MonoBehaviour
{
    private Character character;

    public void SetClothesColor(string color)
    {
        switch (color)
        {
            case "white":
                character.ClothRenderer.material.color = Color.white;
                break;
            case "black":
                character.ClothRenderer.material.color = Color.black;
                break;
            case "brown":
                character.ClothRenderer.material.color = Color.yellow;
                break;
        }
    }
    
    public void SetHairColor(string color)
    {
        switch (color)
        {
            case "white":
                character.HairRenderer.material.color = Color.white;
                break;
            case "black":
                character.HairRenderer.material.color = Color.black;
                break;
            case "brown":
                character.HairRenderer.material.color = Color.yellow;
                break;
        }
    }
    
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetCharacterName(Character character)
    {
        this.character = character;
    }
}