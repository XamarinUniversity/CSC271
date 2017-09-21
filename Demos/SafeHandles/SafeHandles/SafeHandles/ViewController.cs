using System;
using UIKit;

namespace SafeHandles
{
    public partial class ViewController : UIViewController
    {
        protected ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            var number = new BetterMagicNumber ();
            NumberLabel.Text = number.Value.ToString ();
        }
    }
}

