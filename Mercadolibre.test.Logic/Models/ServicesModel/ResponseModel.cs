using System;
using System.Collections.Generic;

namespace Mercadolibre.test.Logic.Models.ServicesModel
{
    public class ResponseModel
    {
        public string site_id { get; set; }
        public string query { get; set; }
        public Paging paging { get; set; }
        public List<Result> results { get; set; }
        public List<object> secondary_results { get; set; }
        public List<object> related_results { get; set; }
        public Sort sort { get; set; }
        public List<AvailableSort> available_sorts { get; set; }
        public List<Filter> filters { get; set; }
        public List<AvailableFilter> available_filters { get; set; }
    }
}
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
public class Paging
{
    public double total { get; set; }
    public double primary_results { get; set; }
    public double offset { get; set; }
    public double limit { get; set; }
}

public class Seller
{
    public double id { get; set; }
    public object permalink { get; set; }
    public object registration_date { get; set; }
    public bool car_dealer { get; set; }
    public bool real_estate_agency { get; set; }
    public object tags { get; set; }
}

public class Conditions
{
    public List<object> context_restrictions { get; set; }
    public object start_time { get; set; }
    public object end_time { get; set; }
    public bool eligible { get; set; }
}

public class Metadata
{
}

public class Price
{
    public string id { get; set; }
    public string type { get; set; }
    public Conditions conditions { get; set; }
    public double amount { get; set; }
    public object regular_amount { get; set; }
    public string currency_id { get; set; }
    public string exchange_rate_context { get; set; }
    public Metadata metadata { get; set; }
    public DateTime last_updated { get; set; }
    public List<Price> prices { get; set; }
    public Presentation presentation { get; set; }
    public List<object> payment_method_prices { get; set; }
    public List<object> reference_prices { get; set; }
    public List<object> purchase_discounts { get; set; }
}

public class Presentation
{
    public string display_currency { get; set; }
}

public class Installments
{
    public double quantity { get; set; }
    public double amount { get; set; }
    public double rate { get; set; }
    public string currency_id { get; set; }
}

public class Address
{
    public string state_id { get; set; }
    public string state_name { get; set; }
    public string city_id { get; set; }
    public string city_name { get; set; }
}

public class Shipping
{
    public bool free_shipping { get; set; }
    public string mode { get; set; }
    public List<string> tags { get; set; }
    public string logistic_type { get; set; }
    public bool store_pick_up { get; set; }
}

public class Country
{
    public string id { get; set; }
    public string name { get; set; }
}

public class State
{
    public string id { get; set; }
    public string name { get; set; }
}

public class City
{
    public string id { get; set; }
    public string name { get; set; }
}

public class SellerAddress
{
    public string id { get; set; }
    public string comment { get; set; }
    public string address_line { get; set; }
    public string zip_code { get; set; }
    public Country country { get; set; }
    public State state { get; set; }
    public City city { get; set; }
    public string latitude { get; set; }
    public string longitude { get; set; }
}

public class Struct
{
    public double number { get; set; }
    public string unit { get; set; }
}

public class Value
{
    public string id { get; set; }
    public string name { get; set; }
    public Struct @struct { get; set; }
    public object source { get; set; }
    public List<PathFromRoot> path_from_root { get; set; }
    public double results { get; set; }
}

public class ValueStruct
{
    public double number { get; set; }
    public string unit { get; set; }
}

public class Attribute
{
    public string id { get; set; }
    public string name { get; set; }
    public string value_id { get; set; }
    public string value_name { get; set; }
    public List<Value> values { get; set; }
    public string attribute_group_name { get; set; }
    public ValueStruct value_struct { get; set; }
    public string attribute_group_id { get; set; }
    public object source { get; set; }
}

public class DifferentialPricing
{
    public double id { get; set; }
}

public class Result
{
    public string id { get; set; }
    public string site_id { get; set; }
    public string title { get; set; }
    public Seller seller { get; set; }
    public double price { get; set; }

    public object sale_price { get; set; }
    public string currency_id { get; set; }
    public double available_quantity { get; set; }
    public double sold_quantity { get; set; }
    public string buying_mode { get; set; }
    public string listing_type_id { get; set; }
    public DateTime stop_time { get; set; }
    public string condition { get; set; }
    public string permalink { get; set; }
    public string thumbnail { get; set; }
    public string thumbnail_id { get; set; }
    public bool accepts_mercadopago { get; set; }
    public Installments installments { get; set; }
    public Address address { get; set; }
    public Shipping shipping { get; set; }
    public SellerAddress seller_address { get; set; }
    public List<Attribute> attributes { get; set; }
    public DifferentialPricing differential_pricing { get; set; }
    public object original_price { get; set; }
    public string category_id { get; set; }
    public object official_store_id { get; set; }
    public string domain_id { get; set; }
    public string catalog_product_id { get; set; }
    public List<string> tags { get; set; }
    public double order_backend { get; set; }
    public bool use_thumbnail_id { get; set; }
}

public class Sort
{
    public string id { get; set; }
    public string name { get; set; }
}

public class AvailableSort
{
    public string id { get; set; }
    public string name { get; set; }
}

public class PathFromRoot
{
    public string id { get; set; }
    public string name { get; set; }
}

public class Filter
{
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public List<Value> values { get; set; }
}

public class AvailableFilter
{
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public List<Value> values { get; set; }
}

