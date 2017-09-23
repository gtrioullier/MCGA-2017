//====================================================================================================
// Base code generated with LeatherGoods - ASF.Services.Contracts
// Architecture Solutions Foundation
//
// Generated by academic at LeatherGoods V 1.0 
//====================================================================================================

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ASF.Entities;


namespace ASF.Services.Contracts
{
    
    [DataContract]
    public class AllCategoryResponse
    {
        [DataMember]
        public List<Category> Result { get; set; }
       
    }

    [DataContract]
    public class AllCountryResponse
    {
        [DataMember]
        public List<Country> Result { get; set; }
    }

    [DataContract]
    public class AllDealerResponse
    {
        [DataMember]
        public List<Dealer> Result { get; set; }
    }

    [DataContract]
    public class AllClientResponse
    {
        [DataMember]
        public List<Client> Result { get; set; }
    }

    [DataContract]
    public class AllProductResponse
    {
        [DataMember]
        public List<Product> Result { get; set; }
    }

    [DataContract]
    public class AllRatingResponse
    {
        [DataMember]
        public List<Rating> Result { get; set; }
    }

    [DataContract]
    public class AllOrderDetailResponse
    {
        [DataMember]
        public List<OrderDetail> Result { get; set; }
    }

    [DataContract]
    public class AllOrderResponse
    {
        [DataMember]
        public List<Order> Result { get; set; }
    }

    [DataContract]
    public class AllCartResponse
    {
        [DataMember]
        public List<Cart> Result { get; set; }
    }

    [DataContract]
    public class AllCartItemResponse
    {
        [DataMember]
        public List<CartItem> Result { get; set; }
    }

    [DataContract]
    public class AllOrderNumberResponse
    {
        [DataMember]
        public List<OrderNumber> Result { get; set; }
    }

    [DataContract]
    public class AllErrorResponse
    {
        [DataMember]
        public List<Error> Result { get; set; }
    }

    [DataContract]
    public class AllSettingResponse
    {
        [DataMember]
        public List<Setting> Result { get; set; }
    }

    [DataContract]
    public class AllLanguageResponse
    {
        [DataMember]
        public List<Language> Result { get; set; }
    }

    [DataContract]
    public class AllLocaleResourceKeyResponse
    {
        [DataMember]
        public List<LocaleResourceKey> Result { get; set; }
    }

    [DataContract]
    public class AllLocaleStringResourceResponse
    {
        [DataMember]
        public List<LocaleStringResource> Result { get; set; }
    }
}

