using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages //new'lememek için static yaparız
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime="Sistem bakımda";
        public static string ProductListed="ürünler listelendi";

        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir.";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceted="Kategori limiti aşıldığı için yeni ürün eklenemez.";
    }
}
