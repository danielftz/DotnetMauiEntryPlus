#nullable enable
using Android.Views;
using Android.Views.InputMethods;
using AView = Android.Views.View;
using Android.Content;
using static Android.Views.View;
using AndroidX.Core.View;

namespace EntryPlus.Platforms.Android
{
    public class AndroidHideKeyboardOnTouchListener : Java.Lang.Object, IOnTouchListener
    {
        InputMethodManager? _imm;
        private readonly bool _isPartOfEntryPlus;
        public AndroidHideKeyboardOnTouchListener(bool isPartOfEntryPlus)
        {
            _imm = Platform.CurrentActivity?.GetSystemService(Context.InputMethodService) as InputMethodManager;
            _isPartOfEntryPlus = isPartOfEntryPlus;
        }

        bool IOnTouchListener.OnTouch(AView? v, MotionEvent? e)
        {

            _imm ??= Platform.CurrentActivity?.GetSystemService(Context.InputMethodService) as InputMethodManager;
            bool isKeyboardShown = WindowInsetsCompat.ToWindowInsetsCompat(Platform.CurrentActivity.Window.DecorView.RootWindowInsets).IsVisible(WindowInsetsCompat.Type.Ime());
            if (_isPartOfEntryPlus is true && isKeyboardShown is true)
            {
                return true;
            }
            else if (isKeyboardShown is true)
            {
                AView? view = Platform.CurrentActivity?.CurrentFocus;
                if (view is not null)
                {
                    _imm.HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
                    return true;
                }
            }
            return false;
           
        }
    }
}
