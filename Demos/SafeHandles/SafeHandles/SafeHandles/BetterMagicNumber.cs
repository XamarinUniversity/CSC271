using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32.SafeHandles;

namespace SafeHandles
{
    public class BetterMagicNumber : IDisposable
    {
        bool disposed;
        MagicNumberSafeHandle safeHandle;

        public BetterMagicNumber ()
        {
            safeHandle = new MagicNumberSafeHandle(CreateMagicNumber ());
            Debug.WriteLine ($"Created BetterMagicNumber: {safeHandle:X}");
        }

        protected virtual void Dispose (bool disposing)
        {
            Debug.WriteLine ($"BetterMagicNumber.Dispose: {safeHandle:X} disposing={disposing}");
            if (!disposed) {
                disposed = true;
                safeHandle.Dispose ();
            }
        }

        public void Dispose ()
        {
            Dispose (true);
        }

        public int Value {
            get {
                if (disposed)
                    throw new ObjectDisposedException ("BetterMagicNumber disposed.");
                return GetValue (safeHandle);
            }
        }

        class MagicNumberSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            MagicNumberSafeHandle() : base(true) {}

            public MagicNumberSafeHandle(IntPtr handle) : base(true)
            {
                SetHandle (handle);
            }

            protected override bool ReleaseHandle ()
            {
                Debug.WriteLine ($"MagicNumberSafeHandle.ReleaseHandle {this}");
                DeleteMagicNumber (handle);
                return true;
            }

            public override string ToString ()
            {
                return DangerousGetHandle ().ToString ("X");
            }
        }

        [DllImport ("__Internal", EntryPoint = "CreateMagicNumber")]
        static extern IntPtr CreateMagicNumber ();

        [DllImport ("__Internal", EntryPoint = "DeleteMagicNumber")]
        static extern void DeleteMagicNumber (IntPtr pObject);

        [DllImport ("__Internal", EntryPoint = "Value")]
        static extern int GetValue (MagicNumberSafeHandle pObject);
    }
}

