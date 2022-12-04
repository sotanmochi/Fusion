namespace ImuFusion
{
    public static class Math
    {
        public static Euler QuaternionToEuler(Quaternion quaternion)
        {
            return NativeApi.QuaternionToEuler(quaternion);
        }
    }

    public struct Vector
    {
        public float X;
        public float Y;
        public float Z;

        public Vector(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    public struct Quaternion
    {
        public float W;
        public float X;
        public float Y;
        public float Z;
    }

    public struct Euler
    {
        public float Roll;
        public float Pitch;
        public float Yaw;
    }

    public struct Matrix
    {

    }
}