using organizerEvents.Controler;
using organizerEvents.model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;


namespace WpfApp1.Controler
{
    public class Validator
    {
        public static void validate(string text, ValidationRule validator)
        {
            var result = validator.Validate(text, null);
            if (!result.IsValid)
                throw new Exception("Molimo vas da ispravno popunite sva polja " + text + " je nevalidan");

        }
    }


    class UsernameValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string username = (string)value;
            if (username == null || username.Length <= 0)
            {
                return new ValidationResult(false, $"Obavezno polje");
            }

            Korisnik korisnik = DataBase.nadjiKorisnika(username);
            if(korisnik != null)
            {
                return new ValidationResult(false, $"Taj Korisnik Vec Postoji");
            }
            return ValidationResult.ValidResult;
        }
    }



    class EmailValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = (string)value;
            if (email == null || email.Length <= 0)
            {
                return new ValidationResult(false, $"Obavezno polje");
            }
            Boolean elValidno = new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email);
            if(elValidno)
                return ValidationResult.ValidResult;
            else
                return new ValidationResult(false, $"Mail nije ispravan");
        }
    }


    class NoEmptyFieldValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            string word = (string)value;
            if (word == null || word.Length <= 0)
            {
                return new ValidationResult(false, $"Obavezno polje");
            }

            return ValidationResult.ValidResult;
        }
    }


    class NumbersValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string word = (string)value;
            if (word == null || word.Length <= 0 || !Regex.Match(word, @"^([0-9]{8}[0-9]*)$").Success)
            {
                return new ValidationResult(false, $"Nije Validan Broj");
            }

            return ValidationResult.ValidResult;
        }
    }

    
}
