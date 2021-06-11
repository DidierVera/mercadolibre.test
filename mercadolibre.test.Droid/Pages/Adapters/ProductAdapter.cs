using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using mercadolibre.test.Droid.Pages.ViewHolders;
using Mercadolibre.test.Logic.Models.SharedModels;

namespace mercadolibre.test.Droid.Pages.Adapters
{
    public class ProductAdapter : RecyclerView.Adapter
    {
        private List<ProductModel> items;
        public event EventHandler<ProductModel> OnItemClicked;
        public ProductAdapter(List<ProductModel> products)
        {
            items = products;
        }

        public override int ItemCount => items.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ProductModel item = items[position];
            ProductViewHolder viewHolder = holder as ProductViewHolder;
            viewHolder.Bind(item);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemVListView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.product_list_item_view, parent, false);
            return new ProductViewHolder(itemVListView, OnClick);
        }

        private void OnClick(int position)
        {
            var item = items[position];
            OnItemClicked?.Invoke(this, item);
        }
    }
}
