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

        [DllImport(DLL_NAME, EntryPoint = "UpdateNoMagnetometer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateNoMagnetometer(AhrsHandle handle, Vector gyroscope, Vector accelerometer, float deltaTime);

        [DllImport(DLL_NAME, EntryPoint = "GetQuaternion", CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion GetQuaternion(AhrsHandle handle);

        [DllImport(DLL_NAME, EntryPoint = "GetEarthAcceleration", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector GetEarthAcceleration(AhrsHandle handle);

        [DllImport(DLL_NAME, EntryPoint = "SetAhrsSettings", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAhrsSettings(AhrsHandle ahrs, AhrsSettingsHandle settings);

        [DllImport(DLL_NAME, EntryPoint = "CreateAhrsSettings", CallingConvention = CallingConvention.Cdecl)]
        public static extern AhrsSettingsHandle CreateAhrsSettings(float gain, float accelerationRejection, float magneticRejection, uint rejectionTimeout);

        [DllImport(DLL_NAME, EntryPoint = "ReleaseAhrsSettings", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ReleaseAhrsSettings(IntPtr handle);

        [DllImport(DLL_NAME, EntryPoint = "CreateOffset", CallingConvention = CallingConvention.Cdecl)]
        public static extern OffsetHandle CreateOffset(uint sampleRate);

        [DllImport(DLL_NAME, EntryPoint = "ReleaseOffset", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ReleaseOffset(IntPtr handle);

        [DllImport(DLL_NAME, EntryPoint = "OffsetUpdate", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector OffsetUpdate(OffsetHandle handle, Vector gyroscope);
    }
}