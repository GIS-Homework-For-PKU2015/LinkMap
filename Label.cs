﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace LinkMapControl
{
    /// <summary>
    /// Defines an axis-aligned box around a label, used for collision detection
    /// </summary>
    public class LabelBox : IComparable<LabelBox>
    {
        private float _height;
        private float _left;
        private float _top;
        private float _width;

        /// <summary>
        /// Initializes a new LabelBox instance
        /// </summary>
        /// <param name="left">Left side of box</param>
        /// <param name="top">Top of box</param>
        /// <param name="width">Width of the box</param>
        /// <param name="height">Height of the box</param>
        public LabelBox(float left, float top, float width, float height)
        {
            _left = left;
            _top = top;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Initializes a new LabelBox instance based on a rectangle
        /// </summary>
        /// <param name="rectangle"></param>
        public LabelBox(RectangleF rectangle)
        {
            _left = rectangle.X;
            _top = rectangle.Y;
            _width = rectangle.Width;
            _height = rectangle.Height;
        }

        /// <summary>
        /// The Left tie-point for the Label
        /// </summary>
        public float Left
        {
            get { return _left; }
            set { _left = value; }
        }

        /// <summary>
        /// The Top tie-point for the label
        /// </summary>
        public float Top
        {
            get { return _top; }
            set { _top = value; }
        }

        /// <summary>
        /// Width of the box
        /// </summary>
        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Height of the box
        /// </summary>
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Right side of the box
        /// </summary>
        public float Right
        {
            get { return _left + _width; }
        }

        /// <summary>
        /// Bottom of the box
        /// </summary>
        public float Bottom
        {
            get { return _top - _height; }
        }

        #region IComparable<LabelBox> Members

        /// <summary>
        /// Returns 0 if the boxes intersects each other
        /// </summary>
        /// <param name="other">labelbox to perform intersectiontest with</param>
        /// <returns>0 if the intersect</returns>
        public int CompareTo(LabelBox other)
        {
            if (Intersects(other))
                return 0;
            else if (other.Left > Right ||
                     other.Bottom > Top)
                return 1;
            else
                return -1;
        }

        #endregion

        /// <summary>
        /// Determines whether the boundingbox intersects another boundingbox
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public bool Intersects(LabelBox box)
        {
            return !(box.Left > Right ||
                     box.Right < Left ||
                     box.Bottom > Top ||
                     box.Top < Bottom);
        }
    }

    /// <summary>
    /// Class for storing a label instance
    /// </summary>
    public abstract class BaseLabel : IComparable<BaseLabel>, IComparer<BaseLabel>
    {
        private LabelBox _box;
        private Font _Font;
        //private PointF _LabelPoint;
        private int _Priority;
        private float _Rotation;
        private bool _show;

        private string _Text;

        /// <summary>
        /// Initializes a new Label instance
        /// </summary>
        /// <param name="text">Text to write</param>
        /// <param name="rotation">Rotation</param>
        /// <param name="priority">Label priority used for collision detection</param>
        /// <param name="collisionbox">Box around label for collision detection</param>
        /// <param name="style">The style of the label</param>
        protected BaseLabel(string text, float rotation, int priority, LabelBox collisionbox)
        {
            _Text = text;
            //_LabelPoint = labelpoint;
            _Rotation = rotation;
            _Priority = priority;
            _box = collisionbox;
            _show = true;
        }
        /// <summary>
        /// Initializes a new Label instance
        /// </summary>
        /// <param name="text"></param>
        /// <param name="rotation"></param>
        /// <param name="priority"></param>
        /// <param name="style"></param>
        protected BaseLabel(string text, float rotation, int priority)
        {
            _Text = text;
            //_LabelPoint = labelpoint;
            _Rotation = rotation;
            _Priority = priority;
            _show = true;
        }

        /// <summary>
        /// Show this label or don't
        /// </summary>
        public bool Show
        {
            get { return _show; }
            set { _show = value; }
        }

        /// <summary>
        /// The text of the label
        /// </summary>
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        /// <summary>
        /// Label font
        /// </summary>
        public Font Font
        {
            get { return _Font; }
            set { _Font = value; }
        }

        /// <summary>
        /// Label rotation
        /// </summary>
        public float Rotation
        {
            get { return _Rotation; }
            set { _Rotation = value; }
        }

        /// <summary>
        /// Value indicating rendering priority
        /// </summary>
        public int Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }

        /// <summary>
        /// Label box
        /// </summary>
        public LabelBox Box
        {
            get { return _box; }
            set { _box = value; }
        }

        #region IComparable<Label> Members

        /// <summary>
        /// Tests if two label boxes intersects
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(BaseLabel other)
        {
            if (this == other)
                return 0;
            if (_box == null)
                return -1;
            if (other.Box == null)
                return 1;
            return _box.CompareTo(other.Box);
        }
        private int CompareToTextOnPath(BaseLabel other)
        {
            if (this == other)
                return 0;
            if (_box == null)
                return -1;
            if (other.Box == null)
                return 1;
            if (other.Box.Left > this.Box.Right ||
                other.Box.Bottom > this.Box.Top)
                return 1;
            else
                return -1;
        }

        #endregion

        #region IComparer<BaseLabel> Members

        /// <summary>
        /// Checks if two labels intersect
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(BaseLabel x, BaseLabel y)
        {
            return x.CompareTo(y);
        }

        #endregion
    }
}
