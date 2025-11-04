using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public enum SpriteTypes
    {
        BlackBg,
        BlackB,
        BlackG,
        Black,
        WhiteBg,
        WhiteB,
        WhiteG,
        White
    }
    public class PlayerSpriteSet : MonoBehaviour
    {
        public SpriteTypes spriteType;
        [SerializeField] private Sprite blackBg;
        [SerializeField] private Sprite blackB;
        [SerializeField] private Sprite blackG;
        [SerializeField] private Sprite black;
        [SerializeField] private Sprite whiteBg;
        [SerializeField] private Sprite whiteB;
        [SerializeField] private Sprite whiteG;
        [SerializeField] private Sprite white;
        
        private Animator _animator;
        private AnimatorOverrideController _baseController;
        [SerializeField] private AnimationClip defaultClip;
        [SerializeField] private AnimationClip altClip;
        private void Awake()
        {
            //B means cap and g means gloves
            if (Singleton.Instance.isBlack && !Singleton.Instance.isGlove && !Singleton.Instance.isCap)
            {
                GetComponent<SpriteRenderer>().sprite = black;
                spriteType = SpriteTypes.Black;
            }
            else if (Singleton.Instance.isBlack && Singleton.Instance.isGlove && !Singleton.Instance.isCap)
            {
                GetComponent<SpriteRenderer>().sprite = blackG;
                spriteType = SpriteTypes.BlackG;
            }
            else if (Singleton.Instance.isBlack && !Singleton.Instance.isGlove && Singleton.Instance.isCap)
            {
                GetComponent<SpriteRenderer>().sprite = blackB;
                spriteType = SpriteTypes.BlackB;
            }
            else if (Singleton.Instance.isBlack && Singleton.Instance.isGlove && Singleton.Instance.isCap)
            {
                GetComponent<SpriteRenderer>().sprite = blackBg;
                spriteType = SpriteTypes.BlackBg;
            }
            else if (Singleton.Instance.isWhite && !Singleton.Instance.isGlove && !Singleton.Instance.isCap)
            {
                GetComponent<SpriteRenderer>().sprite = white;
                spriteType = SpriteTypes.White;
            }
            else if (Singleton.Instance.isWhite && Singleton.Instance.isGlove && !Singleton.Instance.isCap)
            {
                GetComponent<SpriteRenderer>().sprite = whiteG;
                spriteType = SpriteTypes.WhiteG;
            }
            else if (Singleton.Instance.isWhite && !Singleton.Instance.isGlove && Singleton.Instance.isCap)
            {
                GetComponent<SpriteRenderer>().sprite = whiteB;
                spriteType = SpriteTypes.WhiteB;
            }
            else if (Singleton.Instance.isWhite && Singleton.Instance.isGlove && Singleton.Instance.isCap)
            {
                GetComponent<SpriteRenderer>().sprite = whiteBg;
                spriteType = SpriteTypes.WhiteBg;
            }

        }

        private void Start()
        {
            var overrideController = new AnimatorOverrideController(_baseController);
            overrideController[defaultClip] = altClip;
            _animator.runtimeAnimatorController = overrideController;

        }
    }

}
