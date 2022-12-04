using System;
using System.Runtime.InteropServices;

namespace ImuFusion
{
    public sealed class Ahrs : IDisposable
    {
        public Quaternion Quaternion => NativeApi.GetQuaternion(_handle);
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
}