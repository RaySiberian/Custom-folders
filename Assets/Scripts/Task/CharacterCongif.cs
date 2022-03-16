using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class CharacterCongif : ScriptableObject
{
   [SerializeField] private string[] characters;

   public string[] Characters => characters;

   public GameObject GetCharacterByName(string characterName)
   {
      string charName = characters.FirstOrDefault(e => e == characterName);
      return string.IsNullOrEmpty(charName) ? null : LoadObject(characterName);
   }

   private static GameObject LoadObject(string characterName)
   {
      return Resources.Load<GameObject>($"Characters/{characterName}");
   }
}
