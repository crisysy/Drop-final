using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Drop.Models
{
    public class MaxAgeAttribute : ValidationAttribute
    {
        private int _maxAge;

        public MaxAgeAttribute(int maxAge)
        {
            _maxAge = maxAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if(DateTime.TryParse(value.ToString(), out date))
            {
                return date.AddYears(_maxAge) > DateTime.Now && date.AddYears(18) < DateTime.Now;
            }

            return false;
        }


    }
}