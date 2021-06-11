using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Mercadolibre.test.Logic.Models.SharedModels;

namespace mercadolibre.test.Droid.Pages.ViewHolders
{
    public class ProductViewHolder : RecyclerView.ViewHolder
    {
        private readonly TextView _lblProductName;
        private readonly TextView _lblLocation;
        private readonly TextView _lblProductPrice;
        private readonly Button _btnSeeDetails;

        public ProductViewHolder(View itemView, Action<int> clickListener) : base(itemView)
        {
            _lblProductName = itemView.FindViewById<TextView>(Resource.Id.lblProductName);
            _lblLocation = itemView.FindViewById<TextView>(Resource.Id.lblLocation);
            _lblProductPrice = itemView.FindViewById<TextView>(Resource.Id.lblProductPrice);
            _btnSeeDetails = itemView.FindViewById<Button>(Resource.Id.btnSeeDetails);

            if (clickListener != null)
            {
                _btnSeeDetails.Click += (sender, e) => clickListener(LayoutPosition);
            }
        }

        public void Bind(ProductModel item)
        {
            _lblProductName.Text = item.ProductName;
            _lblLocation.Text = string.Format("{0} - {1}",item.State, item.City);
            _lblProductPrice.Text = string.Format("{0:C0}", item.Price);
            _btnSeeDetails.Text = "Ver Detalle";
        }
    }
}
