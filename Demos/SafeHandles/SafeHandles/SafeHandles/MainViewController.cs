using Foundation;
using System;
using UIKit;
using System.Diagnostics;

namespace SafeHandles
{
    public partial class MainViewController : UIViewController
    {
        public MainViewController (IntPtr handle) : base (handle)
        {
        }

        partial void DoGC (UIBarButtonItem sender)
        {
            Debug.WriteLine ("Performing GC.");
            GC.Collect ();
        }
    }
}