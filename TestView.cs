using System;
namespace TestApp {
    public class CustomTextView : View {
        public static BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(CustomTextView), string.Empty);

        public string Text {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public CustomTextView() {
        }
    }
}

