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
        public static string ProductListed = "Ürün Listelendi.";
        public  static string AddedProductCountOfCategoryError = "Bir kategori de en fazla 10 ürün olmalıdır.";
        public static string ProductNameAlreadyDefined = "Eklenmeye çalışılan ürün ismi daha önceden tanımlanmış.";
        public static string CountOfCategoryBoundaryPassed = "Category sayısı 15'i geçemez";
    }
}
