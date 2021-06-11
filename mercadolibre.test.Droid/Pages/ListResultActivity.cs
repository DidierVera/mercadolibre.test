
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using mercadolibre.test.Droid.Pages.Adapters;
using Mercadolibre.test.Logic.Models.SharedModels;
using Newtonsoft.Json;

namespace mercadolibre.test.Droid.pages
{
    [Activity(Label = "Resultado de la búsqueda")]
    public class ListResultActivity : Activity
    {
        private RecyclerView _productsRecyclerView;
        private ProductAdapter _adapter;
        private List<ProductModel> _productsList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string products = Intent.GetStringExtra("products");
            SetContentView(Resource.Layout.list_result_layout);

            _productsList = new List<ProductModel>();
            _productsList = JsonConvert.DeserializeObject<List<ProductModel>>(products);

            LoadView();
            LoadProducts();
        }

        private void LoadView()
        {
            _productsRecyclerView = FindViewById<RecyclerView>(Resource.Id.productsRecycler);
        }

        private void LoadProducts()
        {
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
