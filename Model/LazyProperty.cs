using System;

namespace TechNoir.Data.Entity.Edmx.Model
{
    internal class LazyProperty<T>
    {
        private readonly Func<T> _ValueFunc;
        private          bool    _HaveValue;

        private T _Value;
        public  T Value
        {
            get
            {
                if (_HaveValue) return _Value;
                _HaveValue = true;
                return _Value = _ValueFunc();
            }
        }

        public LazyProperty(Func<T> value_func)
        {
            _ValueFunc = value_func ?? throw new ArgumentNullException(nameof(value_func));
        }
    }
}
