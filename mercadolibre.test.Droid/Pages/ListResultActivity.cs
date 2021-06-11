using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using mercadolibre.test.Droid.Pages.Adapters;
using Mercadolibre.test.Logic.Models.SharedModels;
using Newtonsoft.Json;

namespace mercadolibre.test.Droid.pages
{
    [Activity(Label = "Resultado de la búsqueda", Theme = "@style/AppTheme.NoActionBar")]
    public class ListResultActivity : Activity
    {
        private RecyclerView _productsRecyclerView;
        private ProductAdapter _adapter;
        private List<ProductModel> _productsList;
        private ImageButton _imgBackButton;
        private TextView _lblNoResult;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string products = Intent.GetStringExtra("products");
            SetContentView(Resource.Layout.list_result_layout);

            _productsList = new List<ProductModel>();
            _productsList = JsonConvert.DeserializeObject<List<ProductModel>>(products);

            LoadView();
            LoadProducts();
            SetEvents();
        }

        private void SetEvents()
        {
            _imgBackButton.Click += (sender, e) => OnBackPressed();
        }

        private void LoadView()
        {
            _lblNoResult = FindViewById<TextView>(Resource.Id.lblNoResult);
            _imgBackButton = FindViewById<ImageButton>(Resource.Id.imgBackButton);
            _productsRecyclerView = FindViewById<RecyclerView>(Resource.Id.productsRecycler);
        }

        private void LoadProducts()
        {
            //Show no result message 
            _lblNoResult.Visibility = Android.Views.ViewStates.Gone;
            if (_productsList.Count == 0)
            {
                _lblNoResult.Visibility = Android.Views.ViewStates.Visible;
            }

            //create adapter
            _adapter = new ProductAdapter(_productsList);
            _adapter.OnItemClicked += Adapter_OnItemClick;

            _productsRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            _productsRecyclerView.AddItemDecoration(new DividerItemDecoration(this,
                DividerItemDecoration.Vertical));
            _productsRecyclerView.SetAdapter(_adapter);
        }

        private void Adapter_OnItemClick(object sender, ProductModel product)
        {
            Intent intent = new Intent(this, typeof(ProductDetailActivity));
            intent.PutExtra("oneproduct", JsonConvert.SerializeObject(product));
            StartActivity(intent);
        }
    }
}
