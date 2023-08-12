using CommonCoreLayer.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Business.Constants
{
    public static class Messages
    {
        public static  string ProductAdded = "Ürün başarıyla eklendi";
        public static string ProductDeleted = "Ürün başarıyla silindi";
        public static string ProductUpdated = "Ürün başarıyla güncellendi";

        public static string CategoryAdded = "Kategori başarıyla eklendi";
        public static string CategoryDeleted = "Kategori başarıyla silindi";
        public static string CategoryUpdated = "Kategori başarıyla güncellendi";
        public static string UserAdded;
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Şifre hatalı";
        public static string SuccessLogin="Giriş başarılı";
        public static string UserAlreadyExists="Bu kullanıcızaten mevcut";
        public static string UserRegistered="Kullanıcı başarılı bir şekilde eklendi";
        public static string AccessTokenCreated="Access token başarı ile oluşturuldu";
        public static string ProductAlreadyExist="Bu ürün zaten sistemde mevcut";
    }
}
