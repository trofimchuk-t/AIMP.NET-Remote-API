using System;

namespace AIMP.NET.RemoteAPI
{
    public class AimpEventArgs<T> : EventArgs
    {
        public AimpEventArgs(T obj)
        {
            Value = obj;
        }

        public T Value { get; }
    }
}