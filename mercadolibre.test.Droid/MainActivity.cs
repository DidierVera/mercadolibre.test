using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Mercadolibre.test.Logic.Contract.Presenters;
using Mercadolibre.test.Logic.Presenter;
using System.Collections.Generic;
using Mercadolibre.test.Logic.Models.SharedModels;
using Mercadolibre.test.Logic.Config;
using mercadolibre.test.Droid.Config;
using Autofac;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.Design.Widget;
using Android.Widget;
using Android.Content;
using Newtonsoft.Json;
using mercadolibre.test.Droid.pages;

namespace mercadolibre.test.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IGenericView
    {
        private ProductPresenter _presenter;
        private EditText _edtFilter;
        private Button _btnSearch;
        private ProgressDialog _progressDialog;
        private Android.App.AlertDialog alertDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AppCenter.Start("5d6bbac8-d8b3-4964-9e66-82c90df2040a",
                   typeof(Analytics), typeof(Crashes));

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _progressDialog = new ProgressDialog(this);
            _progressDialog.SetMessage("Cargando datos...");


            LoadDependecies();
            _presenter = new ProductPresenter(this);
            LoadView();
            AddEvents();
        }

        private void LoadView()
        {
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            _edtFilter = FindViewById<EditText>(Resource.Id.edtFilter);
            _btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
        }

        private async void LoadProducts(string filter)
        {
            _progressDialog.Show();
            await _presenter.GetProductsByFilter(filter);
            _progressDialog.Hide();
        }

        private void AddEvents()
        {
            _btnSearch.Click += OnSearchClicked;
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_edtFilter.Text))
            {
                LoadProducts(_edtFilter.Text);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void UpdateView(object model)
        {
            var result = (List<ProductModel>)model;
            Intent intent = new Intent(this, typeof(ListResultActivity));
            intent.PutExtra("products", JsonConvert.SerializeObject(result));
            StartActivity(intent);
        }

        private void LoadDependecies()
        {
            var builder = AutofacConfig.CreateBuilder();
            builder.RegisterModule<DependencyModule>();
            ModuleLocator.ConfigureModules(builder.Build());
        }

        public void ShowAlert(string message)
        {
            _edtFilter.Text = string.Empty;

            Android.App.AlertDialog.Builder builder
                = new Android.App.AlertDialog
                      .Builder(this);

            builder.SetMessage("mensaje del servicio: " + message.Substring(1, 100));
            builder.SetTitle("Ups! Algo ha salido mal");
            builder.SetCancelable(false);
            builder.SetPositiveButton("Aceptar", OnAceptClick);

            // Create the Alert dialog
            alertDialog = builder.Create();
            // Show the Alert Dialog box
            alertDialog.Show();
        }

        private void OnAceptClick(object sender, DialogClickEventArgs e)
        {
            alertDialog.Dispose();
        }
    }
}