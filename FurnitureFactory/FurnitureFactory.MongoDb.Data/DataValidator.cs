namespace FurnitureFactory.MongoDb.Data
{
    using System;
    using Models;

    public static class DataValidator
    {
        private const int MaxNameLength = 50;
        private const int MaxAddressLength = 100;
        private const int MaxMobileLength = 50;
        private const int MaxEmailLength = 50;
        private const int MaxContactName = 50;

        private const string ClientString = "client";
        private const string MaterialString = "material";
        private const string ProductString = "product";
        private const string NameString = "name";

        private const string ErrorMessageFormat = "The {0}'s {1} cannot be longer than {2} symbols.";

        public static void ValidateClient(string name, string address, string mobile, string email, string contact)
        {
            if (!string.IsNullOrEmpty(name) && name.Length > MaxNameLength)
            {
                throw new IndexOutOfRangeException(string.Format(ErrorMessageFormat, ClientString, NameString, MaxNameLength));
            }

            if (!string.IsNullOrEmpty(address) && address.Length > MaxAddressLength)
            {
                throw new IndexOutOfRangeException(string.Format(ErrorMessageFormat, ClientString, "address", MaxAddressLength));
            }

            if (!string.IsNullOrEmpty(mobile) && mobile.Length > MaxMobileLength)
            {
                throw new IndexOutOfRangeException(string.Format(ErrorMessageFormat, ClientString, "mobile", MaxMobileLength));
            }

            if (!string.IsNullOrEmpty(email) && email.Length > MaxEmailLength)
            {
                throw new IndexOutOfRangeException(string.Format(ErrorMessageFormat, ClientString, "email", MaxEmailLength));
            }

            if (!string.IsNullOrEmpty(contact) && contact.Length > MaxContactName)
            {
                throw new IndexOutOfRangeException(string.Format(ErrorMessageFormat, ClientString, "contact", MaxContactName));
            }
        }

        public static void ValidateMaterial(string name)
        {
            if (!string.IsNullOrEmpty(name) && name.Length > MaxNameLength)
            {
                throw new IndexOutOfRangeException(string.Format(ErrorMessageFormat, MaterialString, NameString, MaxNameLength));
            }
        }

        public static void ValidateProduct(string name)
        {
            if (!string.IsNullOrEmpty(name) && name.Length > MaxNameLength)
            {
                throw new IndexOutOfRangeException(string.Format(ErrorMessageFormat, ProductString, NameString, MaxNameLength));
            }
        }
    }
}
