using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    public class SpriteAnimator : IDisposable
    {
        private sealed class Animation
        {
            public AnimState Track;
            public List<Sprite> Sprites;
            public bool Loop = true;
            public float Speed = 10;
            public float Counter = 0;
            public bool Sleeps;

            public void Update()
            {
                if (Sleeps) return;
                Counter += Time.deltaTime * Speed;

                if (Loop)
                {
                    while (Counter > Sprites.Count)
                    {
                        Counter -= Sprites.Count;
                    }
                }
                else if (Counter > Sprites.Count)
                {
                    Counter = Sprites.Count;
                    Sleeps = true;
                }
            }

        }
        private SpriteAnimConfg _config;
        private Dictionary<SpriteRenderer, Animation> _activeAnimations = new Dictionary<SpriteRenderer, Animation>();

        public SpriteAnimator(SpriteAnimConfg config)
        {
            _config = config;
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, AnimState track, bool loop, float speed)
        {
            if (_activeAnimations.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = speed;
                animation.Sleeps = false;
                if (animation.Track != track)
                {
                    animation.Track = track;
                    animation.Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimations.Add(spriteRenderer, new Animation()
                {
                    Track = track,
                    Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites,
                    Loop = loop,
                    Speed = speed

                });
            }
        }

        public void StopAnimation(SpriteRenderer sprite)
        {
            if (_activeAnimations.ContainsKey(sprite))
            {
                _activeAnimations.Remove(sprite);
            }
        }
        public void Update()
        {
            foreach (var animation in _activeAnimations)
            {
                animation.Value.Update();
                if (animation.Value.Counter < animation.Value.Sprites.Count)
                {
                    animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
                }
            }

        }
        public void Dispose()
        {
            _activeAnimations.Clear();
        }
    }
}
