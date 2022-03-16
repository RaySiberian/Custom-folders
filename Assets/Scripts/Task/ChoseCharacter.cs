using UnityEngine;

public class ChoseCharacter : MonoBehaviour
{
    [SerializeField] private CharacterConfigurationPanel configurationPanel;
    private CharacterCongif _congif;
    private string characterName;
    private GameObject character;
    
    private void Start()
    {
        _congif = Resources.Load<CharacterCongif>("CharactersConfig");
    }

    public void ChoseCharacterBtn(string characterName)
    {
        if (character != null)
        {
            Destroy(character);
        }
        this.characterName = characterName;
        character = Instantiate(_congif.GetCharacterByName(characterName));
    }

    public void Chose()
    {
        if (character != null)
        {
            configurationPanel.gameObject.SetActive(true);
            configurationPanel.SetCharacterName(character.GetComponent<Character>());
            gameObject.SetActive(false);
        }
    }
}