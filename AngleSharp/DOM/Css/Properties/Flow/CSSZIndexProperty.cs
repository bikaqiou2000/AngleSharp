﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/z-index
    /// </summary>
    sealed class CSSZIndexProperty : CSSProperty, ICssZIndexProperty
    {
        #region Fields

        Int32? _value;

        #endregion

        #region ctor

        internal CSSZIndexProperty()
            : base(PropertyNames.ZIndex, PropertyFlags.Animatable)
        {
            _value = null;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the index in the stacking order, if any.
        /// </summary>
        public Int32? Index
        {
            get { return _value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            var number = value.ToInteger();

            if (number != null)
                _value = number.Value;
            else if (value.Is(Keywords.Auto))
                _value = null;
            else if (value != CSSValue.Inherit)
                return false;

            return true;
        }

        #endregion
    }
}
