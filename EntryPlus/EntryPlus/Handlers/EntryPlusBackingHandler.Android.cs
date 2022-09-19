#if ANDROID
using AndroidX.AppCompat.Widget;
using EntryPlus.Platforms.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPlus.Handlers
{
    public partial class EntryPlusBackingHandler
    {
        protected override AppCompatEditText CreatePlatformView()
        {
            return new AndroidEntryPlusBacking();
        }
    }
}

#endif
