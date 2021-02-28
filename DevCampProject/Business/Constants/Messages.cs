using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    // Uygulama boyunca only one instance creating
    public static class Messages
    {

        //IMessage interface ile TR,EN desteği yapılabilir
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string ProductRemoved = "Ürün silindi.";
        public static string ProductUpdated = "Ürün güncellendi.";
        public static string MaintenanceTime = "Bakım zamanı.";
        public static string ProductsListed = "Ürünler Listelendi.";
        internal static string ProductListed = "Ürün Listelendi.";
    }
}
