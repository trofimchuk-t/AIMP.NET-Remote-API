using System;

namespace AIMP.NET.RemoteAPI
{
    public class AimpEventArgs<T> : EventArgs
    {
        private T _value;

        public AimpEventArgs(T obj)
        {
            this._value = obj;
        }

        public T GetValue { get { return _value; } }
    }
}
