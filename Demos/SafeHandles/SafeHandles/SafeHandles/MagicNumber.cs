using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SafeHandles
{
    public class MagicNumber : IDisposable
    {
        bool disposed;
        IntPtr handle;

        public MagicNumber ()
        {
            handle = CreateMagicNumber ();
            Debug.WriteLine ($"Created MagicNumber: {handle:X}");
        }

        protected void Dispose(bool disposing)
        {
            Debug.WriteLine ($"MagicNumber.Dispose: {handle:X} disposing={disposing}");
            if (!disposed) {
                disposed = true;
                if (handle != IntPtr.Zero) {
                    DeleteMagicNumber (handle);
                    handle = IntPtr.Zero;
                }
            }
        }

        ~MagicNumber()
        {
            Dispose (false);
        }

        public void Dispose ()
        {
            Dispose (true);
            GC.SuppressFinalize (this);
        }

        public int Value {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException ("MagicNumber disposed.");
                return GetValue (handle);
            }
        }

        [DllImport ("__Internal", EntryPoint = "CreateMagicNumber")]
        static extern IntPtr CreateMagicNumber ();

        [DllImport ("__Internal", EntryPoint = "DeleteMagicNumber")]
        static extern void DeleteMagicNumber (IntPtr pObject);

        [DllImport ("__Internal", EntryPoint = "Value")]
        static extern int GetValue (IntPtr pObject);
    }
}

