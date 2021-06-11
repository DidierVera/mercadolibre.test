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


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
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
            LoadProducts(_edtFilter.Text);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
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
    }
}
