using System;
using System.Runtime.InteropServices;

namespace ImuFusion
{
    public sealed class Ahrs : IDisposable
    {
        public Quaternion Quaternion => NativeApi.GetQuaternion(_handle);
        public Vector EarthAcceleration => NativeApi.GetEarthAcceleration(_handle);
        public bool IsInvalid => _handle.IsInvalid;

        private readonly AhrsHandle _handle;

        public Ahrs()
        {
            _handle = NativeApi.CreateAhrs();
        }

        public void Dispose() => _handle.Dispose();

        public void UpdateNoMagnetometer(Vector gyroscoepe, Vector accelerometer, float deltaTime)
        {
            NativeApi.UpdateNoMagnetometer(_handle, gyroscoepe, accelerometer, deltaTime);
        }

        public void SetSettings(AhrsSettings settings)
        {
            NativeApi.SetAhrsSettings(_handle, settings.Handle);
        }
    }

    internal sealed class AhrsHandle : SafeHandle
    {
        public override bool IsInvalid => IntPtr.Zero == handle;

        private AhrsHandle() : base(invalidHandleValue: IntPtr.Zero, ownsHandle: true)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeApi.ReleaseAhrs(handle);
#if DEVELOPMENT_BUILD
            Console.WriteLine($"[ImuFusion.AhrsHandle] ReleaseHandle is called.");
#endif
            return true;
        }
    }

    public sealed class AhrsSettings : IDisposable
    {
        public bool IsInvalid => _handle.IsInvalid;

        internal AhrsSettingsHandle Handle => _handle;

        private readonly AhrsSettingsHandle _handle;

        public AhrsSettings(float gain, float accelerationRejection, float magneticRejection, uint rejectionTimeout)
        {
            _handle = NativeApi.CreateAhrsSettings(gain, accelerationRejection, magneticRejection, rejectionTimeout);
        }

        public void Dispose() => _handle.Dispose();
    }

    internal sealed class AhrsSettingsHandle : SafeHandle
    {
        public override bool IsInvalid => IntPtr.Zero == handle;

        private AhrsSettingsHandle() : base(invalidHandleValue: IntPtr.Zero, ownsHandle: true)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeApi.ReleaseAhrsSettings(handle);
#if DEVELOPMENT_BUILD
            Console.WriteLine($"[ImuFusion.AhrsSettingsHandle] ReleaseHandle is called.");
#endif
            return true;
        }
    }
}