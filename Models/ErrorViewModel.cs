using System;
using System.ComponentModel.DataAnnotations;

namespace c_sharpPortfolio.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class ContactViewModel
    {
        public string first_name {get;set;}
        public string last_name {get;set;}
        public string email {get;set;}
        public string typeof_app {get;set;}
        public string Comment {get;set;}



    }



}
