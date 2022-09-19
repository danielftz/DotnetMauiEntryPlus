using Android.Content;
using Android.Views;
using AndroidX.AppCompat.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPlus.Platforms.Android
{
    public class AndroidEntryPlusBacking : AppCompatEditText
    {
        public AndroidEntryPlusBacking() : base(Platform.AppContext)
        {
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            return base.OnTouchEvent(e);
        }
    }
}
