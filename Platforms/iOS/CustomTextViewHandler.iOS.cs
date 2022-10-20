using System;
using Microsoft.Maui.Handlers;
using UIKit;

namespace TestApp.Platforms {
    public partial class CustomTextViewHandler : ViewHandler<CustomTextView, UITextView> {
        public static PropertyMapper<CustomTextView, CustomTextViewHandler> CustomTextViewMapper = new PropertyMapper<CustomTextView, CustomTextViewHandler>(ViewHandler.ViewMapper) {
            [nameof(CustomTextView.Text)] = MapText,
        };

        public CustomTextViewHandler() : base(CustomTextViewMapper) {
        }

        protected override UITextView CreatePlatformView() {
            return new UITextView();
        }

        static void MapText(CustomTextViewHandler handler, CustomTextView view) {
            if (handler.PlatformView == null)
                return;

            handler.PlatformView.Text = view.Text;
        }

    }
}

