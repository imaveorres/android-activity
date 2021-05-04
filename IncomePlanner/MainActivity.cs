using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace IncomePlanner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText pph;
        EditText whpd;
        EditText tr;
        EditText sr;

        TextView aws;
        TextView agi;
        TextView atp;
        TextView AS;
        TextView SI;

        Button cal;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            ConnectView();
        }
        void ConnectView()
        {
            pph = FindViewById<EditText>(Resource.Id.textInputEditText1);
            whpd = FindViewById<EditText>(Resource.Id.textInputEditText2);
            tr = FindViewById<EditText>(Resource.Id.textInputEditText3);
            sr = FindViewById<EditText>(Resource.Id.textInputEditText4);

            aws = FindViewById<TextView>(Resource.Id.aws_TOTAL);
            agi = FindViewById<TextView>(Resource.Id.agi_TOTAL);
            atp = FindViewById<TextView>(Resource.Id.atp_TOTAL);
            AS = FindViewById<TextView>(Resource.Id.as_TOTAL);
            SI = FindViewById<TextView>(Resource.Id.SI_TOTAL);

            cal = FindViewById<Button>(Resource.Id.button1);
            cal.Click += CalculateBtnClick;
        }

        private void CalculateBtnClick(object sender, System.EventArgs e)
        {
            double iPerHour = double.Parse(pph.Text);
            double wPerHour = double.Parse(whpd.Text);
            double tRate = double.Parse(tr.Text);
            double sRate = double.Parse(sr.Text);

            double annWorkSummary = wPerHour * 5 * 50;
            double annGrossIncome = iPerHour * wPerHour * 5 * 50;
            double annTaxPayable = (tRate / 100) * annGrossIncome;
            double annSavings = (sRate / 100) * annGrossIncome;
            double spenIncome = annGrossIncome - annSavings - annTaxPayable;

            aws.Text = annWorkSummary.ToString() + "HRS";
            agi.Text = annGrossIncome.ToString() + "PHP";
            atp.Text = annTaxPayable.ToString() + "PHP";
            AS.Text = annSavings.ToString() + "PHP";
            SI.Text = spenIncome.ToString() + "PHP";
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}