
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using mercadolibre.test.Droid.Helpers;
using Mercadolibre.test.Logic.Models.SharedModels;
using Newtonsoft.Json;

namespace mercadolibre.test.Droid.pages
{
    [Activity(Label = "ProductDetailActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class ProductDetailActivity : Activity
    {
        private TextView _lblProductName;
        private TextView _lblLocation;
        private TextView _lblProductPrice;
        private TextView _lblFreeShipping;
        private ImageView _imgProductImage;
        private TextView _lblCondition;
        private TextView _lblSoldQuantity;
        private TextView _lblInstallments;
        private ProductModel _productModel;
        private ImageButton _imgBackButton;
        private Button _btnBack;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string products = Intent.GetStringExtra("oneproduct");
            SetContentView(Resource.Layout.product_detail_layout);
            _productModel = new ProductModel();
            _productModel = JsonConvert.DeserializeObject<ProductModel>(products);
            LoadView();
            LoadProductDetail();
            SetEvent();
        }

        private void SetEvent()
        {
            _btnBack.Click += (sender, e)  => OnBackPressed();
            _imgBackButton.Click += (sender, e) => OnBackPressed();
        }

        private void LoadView()
        {
            _lblProductName = FindViewById<TextView>(Resource.Id.lblProductName);
            _lblLocation = FindViewById<TextView>(Resource.Id.lblLocation);
            _lblProductPrice = FindViewById<TextView>(Resource.Id.lblProductPrice);
            _lblFreeShipping = FindViewById<TextView>(Resource.Id.lblFreeShipping);
            _imgProductImage = FindViewById<ImageView>(Resource.Id.imgProductImage);
            _lblCondition = FindViewById<TextView>(Resource.Id.lblCondition);
            _lblSoldQuantity = FindViewById<TextView>(Resource.Id.lblSoldQuantity);
            _lblInstallments = FindViewById<TextView>(Resource.Id.lblInstallments);
            _btnBack = FindViewById<Button>(Resource.Id.btnBack);
            _imgBackButton = FindViewById<ImageButton>(Resource.Id.imgBackButton);
        }

        private void LoadProductDetail()
        {
            _lblProductName.Text = _productModel.ProductName;
            _lblLocation.Text = string.Format("{0} - {1}", _productModel.State, _productModel.City);
            _lblProductPrice.Text = string.Format("{0:C0}", _productModel.Price);
            _lblFreeShipping.Text = _productModel.FreeShipping;

            //Set image from url
            var imageBitmap = LoadImageHelper.GetImageBitmapFromUrl(_productModel.ImageUrl);
            _imgProductImage.SetImageBitmap(imageBitmap);

            _lblCondition.Text = _productModel.Condition;
            _lblSoldQuantity.Text = string.Format(" | {0} vendidos", _productModel.SoldQuantity);
            _lblInstallments.Text = string.Empty;
            if(_productModel.Installments  != null)
            {
                _lblInstallments.Text = string.Format("en {0}x {1:C0} {2}",
                    _productModel.Installments.Quantity,
                    _productModel.Installments.Amount,
                    (_productModel.Installments.Rate == 0) ? "sin intereses" : "");
            }
        }
    }
}
