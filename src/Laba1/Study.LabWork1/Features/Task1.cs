namespace Study.LabWork1.Features;

///<summary> rgba pixel class</summary>
public class RgbaPixel
{
    private byte _r;
    private byte _g;
    private byte _b;
    private float _a;

    ///<summary>red channel</summary>
    public byte Red
    {
        get => _r;
        set => _r = (byte)Math.Clamp((int)value, 0, 255);
    }

    ///<summary>green channel</summary>
    public byte Green
    {
        get => _g;
        set => _g = (byte)Math.Clamp((int)value, 0, 255);
    }

    ///<summary>blue channel</summary>
    public byte Blue
    {
        get => _b;
        set => _b = (byte)Math.Clamp((int)value, 0, 255);
    }

    ///<summary>alphachannel</summary>
    public float Alpha
    {
        get => _a;
        set => _a = (float)Math.Clamp(value, 0, 1);
    }

    ///<summary>rgba pixel class constructor</summary>
    public RgbaPixel(byte r, byte g, byte b, float a)
    {
        Red = r; Green = g; Blue = b; Alpha = a;
    }

    ///<summary>Addition operator overload</summary>
    public static RgbaPixel operator +(RgbaPixel obj1, RgbaPixel obj2)
    {
        return new RgbaPixel(
            (byte)Math.Clamp(obj1.Red + obj2.Red, 0, 255),
            (byte)Math.Clamp(obj1.Green + obj2.Green, 0, 255),
            (byte)Math.Clamp(obj1.Blue + obj2.Blue, 0, 255),
            (float)Math.Clamp(obj1.Alpha + obj2.Alpha, 0f, 1f)
        );
    }

    ///<summary>Subtraction operator overload</summary>
    public static RgbaPixel operator -(RgbaPixel obj1, RgbaPixel obj2)
    {
        return new RgbaPixel(
            (byte)Math.Clamp(obj1.Red - obj2.Red, 0, 255),
            (byte)Math.Clamp(obj1.Green - obj2.Green, 0, 255),
            (byte)Math.Clamp(obj1.Blue - obj2.Blue, 0, 255),
            (float)Math.Clamp(obj1.Alpha - obj2.Alpha, 0f, 1f)
        );
    }

    ///<summary>Subtraction operator overload</summary>
    public static RgbaPixel operator *(RgbaPixel obj, int value)
    {
        return new RgbaPixel(
            (byte)Math.Clamp(value * obj.Red, 0, 255),
            (byte)Math.Clamp(value * obj.Green, 0, 255),
            (byte)Math.Clamp(value * obj.Blue, 0, 255),
            (float)Math.Clamp(value * obj.Alpha, 0f, 1f)
        );
    }

    ///<summary>Multiplying operator overload</summary>
    public static RgbaPixel operator *(int value, RgbaPixel obj)
    {
        return new RgbaPixel(
            (byte)Math.Clamp(value * obj.Red, 0, 255),
            (byte)Math.Clamp(value * obj.Green, 0, 255),
            (byte)Math.Clamp(value * obj.Blue, 0, 255),
            (float)Math.Clamp(value * obj.Alpha, 0f, 1f)
        );
    }

    ///<summary>Multiplying commutativity operator overload</summary>
    public static RgbaPixel operator /(RgbaPixel obj, int value)
    {
        if (value == 0)
        {
            throw new DivideByZeroException();
        }

        return new RgbaPixel(
            (byte)Math.Clamp(obj.Red / value, 0, 255),
            (byte)Math.Clamp(obj.Green / value, 0, 255),
            (byte)Math.Clamp(obj.Blue / value, 0, 255),
            (float)Math.Clamp(obj.Alpha / value, 0f, 1f)
        );
    }

    ///<summary>Equals operator overload</summary>
    public static bool operator ==(RgbaPixel obj1, RgbaPixel obj2)
    {
        return (obj1.Red == obj2.Red) && (obj1.Green == obj2.Green) && (obj1.Blue == obj2.Blue) && (obj1.Alpha == obj2.Alpha);
    }

    ///<summary>Equals function overload</summary>
    public override bool Equals(object obj)
    {
        if (obj is RgbaPixel other)
            return this == other;
        return false;
    }

    ///<summary>GetHashCode function overload</summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(Red, Green, Blue, Alpha);
    }

    ///<summary>UnEquals operator overload</summary>
    public static bool operator !=(RgbaPixel obj1, RgbaPixel obj2)
    {
        return !(obj1 == obj2);
    }
}
