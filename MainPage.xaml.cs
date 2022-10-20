namespace TestApp;

public partial class MainPage : ContentPage {
    CustomTextView customControl;
    int count = 0;

    public MainPage() {
        InitializeComponent();
    }

    private void OnAddPressed(object sender, EventArgs e) {
        if (customControl == null) {
            customControl = new CustomTextView() { Text = "CustomTextView " + count };
            count++;
            Refs.AddRef(customControl);
            //customControl.Loaded += OnLoaded;
            //customControl.Unloaded += OnUnloaded;
            container.Add(customControl);
        }
    }

    private void OnRemovePressed(object sender, EventArgs e) {
        if (customControl != null) {
            container.Remove(customControl);
            customControl = null;
        }
    }

    private void OnUnloaded(object sender, EventArgs e) {
        customControl.Unloaded -= OnUnloaded;
        customControl.Handler.DisconnectHandler();
    }

    private void OnLoaded(object sender, EventArgs e) {
        customControl.Loaded -= OnLoaded;
        Refs.AddRef(customControl.Handler);
        Refs.AddRef(customControl.Handler.PlatformView);
    }

    private void Print_Button_Pressed(object sender, EventArgs e) {
        Refs.Print();
    }
}


