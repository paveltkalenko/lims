using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Domain.Model.Entities;
namespace Application.Services.ViewModels
{
    public class ListOfUsers
    {
        [DisplayName("Сис.имя пользователя")]
        public string Usrnam { get; set; }
        [DisplayName("fullname suck")]
        public string Fullname { get; set; }
        [DisplayName("status suck")]
        public string Status { get; set; }
        

    }
}
