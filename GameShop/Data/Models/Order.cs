using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; } 

        [Display(Name = "Введите имя")]     // get client data
        [StringLength(40, MinimumLength = 2)]
        [Required(ErrorMessage = "Длина имени не менее 2-ух символов")]
        public string ClientName { get; set; }

        [Display(Name = "Введите адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Длина адреса не менее 3-ух символов")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
