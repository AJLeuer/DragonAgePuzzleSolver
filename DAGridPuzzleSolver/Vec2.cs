using System;
using System.Reflection;

namespace System
{
    interface IIndexable<N>
    {
        N this[uint index] {get; set;}
    }
}

namespace Chess.Util
{
    public struct Vec2<N> : IIndexable<N> where N:
        struct,
        IComparable, 
        IComparable<N>, 
        IConvertible, 
        IEquatable<N>, 
        IFormattable
    {

        public override int GetHashCode()
        {
            unchecked
            {
                return (x.GetHashCode() * 397) ^ y.GetHashCode();
            }
        }

        public N x { get; set; } 
        public N y { get; set; } 

        public Vec2(Vec2<N> other) :
            this(other.x, other.y)
        {
            
        }

        public Vec2(N x, N y)
        {
            this.x = x;
            this.y = y;
        }

        public Vec2<OtherNumericType> ConvertMemberType <OtherNumericType>() where OtherNumericType : 
            struct, IComparable, IComparable<OtherNumericType>, IConvertible, IEquatable<OtherNumericType>, IFormattable
        {
            return new Vec2<OtherNumericType>((OtherNumericType) (dynamic) x, (OtherNumericType) (dynamic) y);
        }

        public N this[uint index]
        {
            get
            {
                if (index == 0)
                {
                    return x;
                }
                else if (index == 1)
                {
                    return y;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (index == 0)
                {
                    x = value;
                }
                else if (index == 1)
                {
                    y = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        public bool Equals(Vec2<N> other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vec2<N> && Equals((Vec2<N>) obj);
        }
        
        public static bool operator == (Vec2<N> vector0, Vec2<N> vector1)
        {
            return vector0.x.Equals(vector1.x) && vector0.y.Equals(vector1.y);
        }

        public static bool operator !=(Vec2<N> vector0, Vec2<N> vector1)
        {
            return !(vector0 == vector1);
        }

        public static Vec2<N> operator + (Vec2<N> vector0, Vec2<N> vector1)
        {
            dynamic vector0X = vector0.x;
            dynamic vector1X = vector1.x;
            
            dynamic vector0Y = vector0.y;
            dynamic vector1Y = vector1.y;

            N x = (N)(vector0X + vector1X);
            N y = (N)(vector0Y + vector1Y);
            
            return new Vec2<N>(x, y);
        }

        public static Vec2<N> operator - (Vec2<N> vector0, Vec2<N> vector1)
        {
            dynamic vector0X = vector0.x;
            dynamic vector1X = vector1.x;
            
            dynamic vector0Y = vector0.y;
            dynamic vector1Y = vector1.y;

            N x = (N)(vector0X - vector1X);
            N y = (N)(vector0Y - vector1Y);
            
            return new Vec2<N>(x, y);
        }
        
        public static Vec2<N> operator * (Vec2<N> vector, uint n)
        {
            return new Vec2<N>((dynamic) vector.x * n, (dynamic) vector.y * n);
        }
        
        public static Vec2<N> operator / (Vec2<N> vector, N n)
        {
            return new Vec2<N>((dynamic) vector.x / n, (dynamic) vector.y / n);
        }

    }
    
    
}