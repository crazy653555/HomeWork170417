using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWork.Models.ViewModels
{
    public class 客戶聯絡人批次更新ViewModle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string 職稱 { get; set; }

        [Required]
        [RegularExpression(@"\d{4}-\d{6}", ErrorMessage = "電話格式必須為0938-XXXXXX")]
        public string 手機 { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        public string 電話 { get; set; }
    }
}