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
        WindowInsets? _rootWindowInsets;
        private readonly bool _isPartOfEntryPlus;
        public AndroidHideKeyboardOnTouchListener(bool isPartOfEntryPlus)
        {
            _imm = Platform.CurrentActivity?.GetSystemService(Context.InputMethodService) as InputMethodManager;
            _isPartOfEntryPlus = isPartOfEntryPlus;
        }

        bool IOnTouchListener.OnTouch(AView? v, MotionEvent? e)
        {
            _imm ??= Platform.CurrentActivity?.GetSystemService(Context.InputMethodService) as InputMethodManager;
            _rootWindowInsets ??= Platform.CurrentActivity?.Window?.DecorView.RootWindowInsets;
            if (_rootWindowInsets is not null && _imm is not null)
            {
                bool isKeyboardShown = WindowInsetsCompat.ToWindowInsetsCompat(_rootWindowInsets).IsVisible(WindowInsetsCompat.Type.Ime());
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
            }
            return false;
        }
    }
}
