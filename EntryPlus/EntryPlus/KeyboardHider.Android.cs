#if ANDROID
#nullable enable
using AView = Android.Views.View;
using EntryPlus.Platforms.Android;


namespace EntryPlus
{
    public static partial class KeyboardHider
    {
        public static void SetupKeyboardHider(this VisualElement visualElement, bool isPartOfEntryPlus = false)
        {

            //special case when traversed to EntryPlus and all its children
            EntryPlus? entryPlus = visualElement as EntryPlus;
            if (entryPlus is not null)
            {
                //set up listener for self
                AttachOnTouchListener(entryPlus, true);
                if (entryPlus.Content is not null)
                {
                    SetupKeyboardHider(entryPlus.Content, true);
                }
                return;
            }

            //special case when traversed to EntryPlusBacking individually (shouldnt happen)
            if (visualElement.GetType() == typeof(EntryPlusBacking))
            {
                AttachOnTouchListener(visualElement, true);
                return;
            }

            AttachOnTouchListener(visualElement, isPartOfEntryPlus);

            Layout? layout = visualElement as Layout;
            if (layout is not null)
            {
                foreach (View c in layout.Children.Cast<View>())
                {
                    SetupKeyboardHider(c, isPartOfEntryPlus);
                }
                return;
            }

            IContentView? contentView = visualElement as IContentView;
            if (contentView is not null)
            {
                VisualElement? content = contentView.Content as VisualElement;
                if (content is not null)
                {
                    SetupKeyboardHider(content, isPartOfEntryPlus);
                }
                return;
            }

            ContentPage? contentPage = visualElement as ContentPage;
            if (contentPage is not null && contentPage.Content is not null)
            {
                SetupKeyboardHider(contentPage.Content, isPartOfEntryPlus);
                return;
            }
        }

        private static void AttachOnTouchListener(VisualElement visualElement, bool isPartOfEntryPlus)
        {
            AView? aView = visualElement.Handler?.PlatformView as AView;
            aView?.SetOnTouchListener(new AndroidHideKeyboardOnTouchListener(isPartOfEntryPlus));
        }
       
    }
}
#endif