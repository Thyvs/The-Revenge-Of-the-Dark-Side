﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
 
namespace TRODS
{
    class Sprite
    {
        private Texture2D _texture;
        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        private Rectangle _position;
        public Rectangle Position
        {
            get { return _position; }
            set { _position = value; }
        }


        private Vector2 _direction;
        public Vector2 Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        private float _vitesse;
        public float Vitesse
        {
            get { return _vitesse; }
            set { _vitesse = value; }
        }

        private bool _isRelativePos;
        private float _relativePosX;
        private float _relativePosY;
        private float _relativeWidth;
        private float _relativeHeight;

        public Sprite(Rectangle aposition, int windowWidth = 0, int windowHeight = 0)
        {
            _position = aposition;
            _direction = new Vector2();
            _vitesse = 0;
            if (windowWidth > 0 && windowHeight > 0)
            {
                _relativePosX = (float)aposition.X / (float)windowWidth;
                _relativePosY = (float)aposition.Y / (float)windowHeight;
                _relativeWidth = (float)aposition.Width / (float)windowWidth;
                _relativeHeight = (float)aposition.Height / (float)windowHeight;
                _isRelativePos = true;
            }
            else
                _isRelativePos = false;
        }

        public virtual void LoadContent(ContentManager content, string assetName)
        {
            _texture = content.Load<Texture2D>(assetName);
        }
        public void Update(float elapsedTime)
        {
            _position.X += (int)(_vitesse * _direction.X * elapsedTime);
            _position.Y += (int)(_vitesse * _direction.Y * elapsedTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
        public void DrawWith(SpriteBatch spriteBatch, Color color, int X, int Y)
        {
            spriteBatch.Draw(_texture,
                            new Rectangle(X, Y, _position.Width, _position.Height),
                            color);
        }
        public void DrawWith(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(_texture, _position, color);
        }

        public void setRelatvePos(Rectangle aposition, int windowWidth, int windowHeight)
        {
            _position = aposition;
            if (windowWidth > 0 && windowHeight > 0)
            {
                _relativePosX = (float)aposition.X / (float)windowWidth;
                _relativePosY = (float)aposition.Y / (float)windowHeight;
                _relativeWidth = (float)aposition.Width / (float)windowWidth;
                _relativeHeight = (float)aposition.Height / (float)windowHeight;
                _isRelativePos = true;
            }
            else
                _isRelativePos = false;
        }
        public void windowResized(Rectangle rect)
        {
            if (_isRelativePos)
            {
                _position = new Rectangle(
                    (int)(_relativePosX * rect.Width),
                    (int)(_relativePosY * rect.Height),
                    (int)(_relativeWidth * rect.Width),
                    (int)(_relativeHeight * rect.Height));
            }
        }
        public void Dispose()
        {
            _texture.Dispose();
        }
    }
}