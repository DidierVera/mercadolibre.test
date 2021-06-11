package crc64adc5dd00fc7be940;


public class ProductViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("mercadolibre.test.Droid.Pages.ViewHolders.ProductViewHolder, mercadolibre.test.Droid", ProductViewHolder.class, __md_methods);
	}


	public ProductViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == ProductViewHolder.class)
			mono.android.TypeManager.Activate ("mercadolibre.test.Droid.Pages.ViewHolders.ProductViewHolder, mercadolibre.test.Droid", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
