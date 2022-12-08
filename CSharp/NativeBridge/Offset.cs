using System;
using System.Runtime.InteropServices;

namespace ImuFusion
{
    public sealed class Offset : IDisposable
    {
        private readonly OffsetHandle _handle;

        public Offset(uint sampleRate)
        {
            _handle = NativeApi.CreateOffset(sampleRate);
        }

        public void Dispose() => _handle.Dispose();

        public Vector Update(Vector gyroscoepe)
        {
            return NativeApi.OffsetUpdate(_handle, gyroscoepe);
        }
    }

    internal sealed class OffsetHandle : SafeHandle
    {
        public override bool IsInvalid => IntPtr.Zero == handle;

        private OffsetHandle() : base(invalidHandleValue: IntPtr.Zero, ownsHandle: true)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeApi.ReleaseOffset(handle);
#if DEVELOPMENT_BUILD
            Console.WriteLine($"[ImuFusion.OffsetHandle] ReleaseHandle is called.");
#endif
            return true;
        }
    }
}