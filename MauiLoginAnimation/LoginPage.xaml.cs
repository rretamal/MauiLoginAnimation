using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using SkiaSharp.Extended.UI.Controls;

namespace MauiLoginAnimation;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        btnLogin.Clicked += BtnLogin_Clicked;
        
    }

    private async void BtnLogin_Clicked(object? sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtPassword.Text))
        {
            ShowMessage("I think you missed something");

            ChangeAnimationAndReturn("putpassword.json");

            return;
        }

        ShowMessage("Now we are talking!");
        ChangeAnimationAndReturn("cowboyface.json");
    }

    private void OnLottieViewTapped(object sender, EventArgs e)
    {
        ShowMessage("Ouch!");

        ChangeAnimationAndReturn("dizzyface.json");
    }

    private void OnSwipe(object sender, SwipedEventArgs e)
    {
        ShowMessage("Hahahahaha");
        ChangeAnimationAndReturn("laughingface.json");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private void ChangeAnimationAndReturn(string newAnimationFile)
    {
        // Save the file name of the original animation
        var originalAnimationFile = new SKFileLottieImageSource { File = "happyface.json" };

        // Change the animation of the AnimationView to the new JSON file.
        faceView.RepeatCount = 0;
        faceView.Source = new SKFileLottieImageSource { File = newAnimationFile };
        
        // Subscribe to the AnimationCompleted event to switch back to the original animation
        faceView.AnimationCompleted += (sender, args) =>
        {
            // Switch back to the original animation
            faceView.RepeatCount = -1;
            faceView.Source = originalAnimationFile;
            faceView.IsAnimationEnabled = true;
        };

        faceView.IsAnimationEnabled = true;
    }

    private void ShowMessage(string message)
    {
        var snackbar = Snackbar.Make(message, visualOptions: new SnackbarOptions()
        {
            BackgroundColor = Color.FromArgb("#FFFCBA03"),
            TextColor = Color.FromArgb("#FF000000"),
            ActionButtonTextColor = Color.FromArgb("#FFFCBA03"),
            Font = Microsoft.Maui.Font.SystemFontOfSize(20, FontWeight.Bold),
            CornerRadius = new CornerRadius(12),

        }, anchor: faceView);
        snackbar.Show();
    }
}