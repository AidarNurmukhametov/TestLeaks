using System;
using Android.Widget;
using Microsoft.Maui.Handlers;

namespace TestApp.Platforms {
    public partial class CustomTextViewHandler : ViewHandler<CustomTextView, TextView> {
        public static PropertyMapper<CustomTextView, CustomTextViewHandler> CustomTextViewMapper = new PropertyMapper<CustomTextView, CustomTextViewHandler>(ViewHandler.ViewMapper) {
            [nameof(CustomTextView.Text)] = MapText,
        };

        public CustomTextViewHandler() : base(CustomTextViewMapper) {
        }

        protected override TextView CreatePlatformView() {
            return new TextView(Context);
        }

        static void MapText(CustomTextViewHandler handler, CustomTextView view) {
            if (handler.PlatformView == null)
                return;

            handler.PlatformView.Text = view.Text;
        }

    }
}

