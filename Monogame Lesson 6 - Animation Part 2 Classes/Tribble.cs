using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Monogame_Lesson_6___Animation_Part_2_Classes
{
    internal class Tribble
    {
        private int randomNum;

        private Texture2D _texture;
        private Rectangle _rectangle;
        private Vector2 _speed;

        private Random _generator = new Random();
        
        public Tribble(Texture2D texture, Rectangle rect, Vector2 speed)
        {
            _texture = texture;
            _rectangle = rect;
            _speed = speed;
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }

        public Rectangle Bounds
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }

        public void Move(Rectangle window)
        {
            _rectangle.Offset(_speed);

            randomNum = _generator.Next(0, 2);

            if (_rectangle.Right > window.Width)
            {
                _speed.X *= -1;
                if (randomNum == 0)
                    _speed.X -= 1;
                else if (randomNum == 1)
                    _speed.X += 1;
            }
            else if (_rectangle.Left < 0)
            {
                _speed.X *= -1;
                if (randomNum == 0)
                    _speed.X -= 1;
                else if (randomNum == 1)
                    _speed.X += 1;
            }
            if (_rectangle.Bottom > window.Height)
            {
                _speed.Y *= -1;
                if (randomNum == 0)
                    _speed.Y -= 1;
                else if (randomNum == 1)
                    _speed.Y += 1;
            }
            else if (_rectangle.Top < 0)
            {
                _speed.Y *= -1;
                if (randomNum == 0)
                    _speed.Y -= 1;
                else if (randomNum == 1)
                    _speed.Y += 1;
            }
        }
    }
}
