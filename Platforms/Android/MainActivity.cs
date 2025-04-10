using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace SingleTopOverrideWindowProblem
{
    [Activity(Name = "com.test.singletopoverridewindowproblem.MainActivity", Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
        }

        protected override void OnNewIntent(Intent? intent)
        {
            if (intent == null)
            {
                return;
            }

            switch (intent.Action)
            {
                case Intent.ActionSend:
                    intent.SetFlags(ActivityFlags.ClearTask);
                    break;
                case Intent.ActionView:
                    intent.SetFlags(ActivityFlags.ClearTask);
                    break;
            }
        }

        protected override void OnResume()
        {
            base.OnResume();

            var intent = Platform.CurrentActivity?.Intent;
            if (intent != null)
            {
                this.OnNewIntent(intent);
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnActivityResult(Int32 requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}
