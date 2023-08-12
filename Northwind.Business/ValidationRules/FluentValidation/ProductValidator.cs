using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //Ürün ismi boş geçilemez (WithMessage() ile hata mesajını yansıtır.)
            RuleFor(p => p.Name).NotEmpty();

            //Ürün ismi en az 2, en fazla 30 karakter olmalı
            RuleFor(p => p.Name).Length(2, 30);

            RuleFor(p => p.Name).NotEmpty();

            //Ürün fiyatları 1 e eşit veya büyük olmalı
            RuleFor(p => p.Price).GreaterThanOrEqualTo(1);

            //ürün fiyatı categori si 1 olduğunda 10 a elit veya büyük olmalı
            RuleFor(p => p.Price).GreaterThanOrEqualTo(10).When(p=>p.CategoryID==1);

            //CustomeValidaiton belirtmek için Must yazılır.
            RuleFor(p => p.Name).Must(StartWithWithA);


        }

        //Ürün adı A ile başlamalı
        private bool StartWithWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
