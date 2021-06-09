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
            Console.WriteLine(result);
            Console.WriteLine(text);
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
                return new ValidationResult(false, $"");
            }

            Korisnik korisnik = DataBase.nadjiKorisnika(username);
            if(korisnik != null && (DataBase.trenutniKorisnik != korisnik))
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
                return new ValidationResult(false, $"");
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
                return new ValidationResult(false, $"");
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
                return new ValidationResult(false, $"");
            }

            return ValidationResult.ValidResult;
        }
    }
    class NumbersValidatorNumerals : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string word = (string)value;
            if (word == null || word.Length <= 0 || !Regex.Match(word, @"^([0-9]+\.?[0-9]*)$").Success)
            {
                return new ValidationResult(false, $"");
            }

            return ValidationResult.ValidResult;
        }
    }


    class DateValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value == null) return new ValidationResult(false, $"");
            DateTime date = DateTime.Parse((string)value);
            DateTime now = DateTime.Now;

            if (date == null || date <= now)
            {
                return new ValidationResult(false, $"Datum mora biti u buducem terminu");
            }

            return ValidationResult.ValidResult;
        }
    }

    class TimeValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value == null) return new ValidationResult(false, $"");
            DateTime time = DateTime.Parse((string)value);

            if (time == null || time.Hour < 7 || time.Hour > 20)
            {
                return new ValidationResult(false, $"Vreme mora biti izmedju 07:00-20:00");
            }

            return ValidationResult.ValidResult;
        }
    }

}
