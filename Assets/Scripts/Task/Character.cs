using UnityEngine;

    public class Character : MonoBehaviour
    {
        [SerializeField] private Renderer hairRenderer;
        [SerializeField] private Renderer clothRenderer;

        public Renderer HairRenderer => hairRenderer;
        public Renderer ClothRenderer => clothRenderer;
    }
