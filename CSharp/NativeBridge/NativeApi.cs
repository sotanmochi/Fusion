using System;
using System.Runtime.InteropServices;

namespace ImuFusion
{
    internal static class NativeApi
    {
        public const string DLL_NAME = "ImuFusion.Native";

        [DllImport(DLL_NAME, EntryPoint = "QuaternionToEuler", CallingConvention = CallingConvention.Cdecl)]
        public static extern Euler QuaternionToEuler(Quaternion quaternion);

        [DllImport(DLL_NAME, EntryPoint = "CreateAhrs", CallingConvention = CallingConvention.Cdecl)]
        public static extern AhrsHandle CreateAhrs();

        [DllImport(DLL_NAME, EntryPoint = "ReleaseAhrs", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ReleaseAhrs(IntPtr handle);

        [DllImport(DLL_NAME, EntryPoint = "GetQuaternion", CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion GetQuaternion(AhrsHandle handle);

        [DllImport(DLL_NAME, EntryPoint = "UpdateNoMagnetometer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateNoMagnetometer(AhrsHandle handle, Vector gyroscope, Vector accelerometer, float deltaTime);
    }
}