using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Monogame_Lesson_6___Animation_Part_2_Classes
{
    internal class Tribble
    {
        private Texture2D _texture;
        private Rectangle _rectangle;
        private Vector2 _speed;
        
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

            if (_rectangle.Right > window.Width || _rectangle.Left < 0)
                _speed.X *= -1;
            if (_rectangle.Bottom > window.Height || _rectangle.Top < 0)
                _speed.Y *= -1;
        }
    }
}
