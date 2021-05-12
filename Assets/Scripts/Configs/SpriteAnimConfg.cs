using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    [CreateAssetMenu(fileName = "SpriteAnimConfig", menuName = "Configs/AnimationConfg", order = 1)]
    public class SpriteAnimConfg : ScriptableObject
    {
        [Serializable]
        public sealed class SpriteSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }
        public List<SpriteSequence> Sequences = new List<SpriteSequence>();
    }
}