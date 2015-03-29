using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Game2015
{

    abstract class AnimatedSprite 
    {

        public enum myDirection { NONE, LEFT, RIGHT, UP, DOWN };

        protected myDirection currentDirection = myDirection.NONE;

        protected Texture2D sTexture;
        protected Vector2 sPosition;

       // private int xFrameIndex;
        //private int yFrameIndex;
        private int frameIndex;

        private double timeElapsed;
        private double timeToUpdate;

        protected string currentAnimation;

        protected Vector2 sDirection = Vector2.Zero;

        public int FramesPerSecond
        {
            set { timeToUpdate = (1f / value); }
        }

        private Dictionary<string, Rectangle[]> sAnimations = new Dictionary<string, Rectangle[]>();
        private Dictionary<string, Vector2> sOffSets = new Dictionary<string, Vector2>();


        public AnimatedSprite(Vector2 position)
        {
            sPosition = position;
        }


        public void AddAnimation(int frames, int yPosition, int xStartFrame, string name, int sWidth, int sHeight, Vector2 offSet)
        {

            //Creates an array of rectangles which will be used when playing an animation
            Rectangle[] Rectangles = new Rectangle[frames];

            //Fills up the array of rectangles
            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStartFrame) * sWidth, yPosition, sWidth, sHeight);
            }

            sAnimations.Add(name, Rectangles);
            sOffSets.Add(name, offSet);
            Debug.WriteLine(sAnimations[name].Length);
        }
        public virtual void Update(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

            if(timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if(frameIndex < sAnimations[currentAnimation].Length - 1)
                {
                    frameIndex++;
                }
                else
                {
                    AnimationDone(currentAnimation);
                    frameIndex = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(sTexture, sPosition + sOffSets[currentAnimation], sAnimations[currentAnimation][frameIndex], Color.White);

        }

        public void PlayAnimation(string name)
        {
            if(currentAnimation != name && currentDirection == myDirection.NONE)
            {
                currentAnimation = name;
                frameIndex = 0;
            }
        }

        public abstract void AnimationDone(string animation);
       


    }

}
