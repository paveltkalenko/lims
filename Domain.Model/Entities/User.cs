using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Domain.Model.Entities
{
    [DisplayName("Пользователь")]
    public class User
    {
        [DisplayName("Системное имя пользователя")]
        public string Usrnam { get; set; }
        [DisplayName("Полное имя пользователя")]
        public string Fullname { get; set; }
        [DisplayName("Отдел")]
        public string Dept { get; set; }
        [DisplayName("Должность")]
        public string JobDescription { get; set; }
        [DisplayName("Статус учетной записи")]
        public string Status { get; set; }
        
    }

    public enum Statuses
    {
        Active,
        Hold,
        Retired
    }

}
