using System;

namespace Lab01
{
    internal class User
    {
        //Wrong Naming
        private static readonly string[] ChineeseZodiacs = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep" };

        private readonly DateTime _dateOfBirth;
        private readonly int _age;
        //Wrong Naming
        private readonly string _westernZodiac;
        private readonly string _chineeseZodiac;

        internal User(DateTime dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
            _westernZodiac = GetWesternZodiac();
            _chineeseZodiac = GetEasternZodiac();
            _age = GetAge();
        }
        //Wrong Naming
        public string WesternZodiac { get { return _westernZodiac; } }
        public string ChineeseZodiac { get { return _chineeseZodiac; } }
        public int Age { get { return _age; } }
        //Date Of Birth cannot be changed after user is created, so setter is redundant
        internal DateTime DateOfBirth { get => _dateOfBirth; }
        //You don't need to pass date of birth to this method
        private int GetAge()
        {
            int age = DateTime.Today.Year - _dateOfBirth.Year;
            if (DateTime.Today.Month < _dateOfBirth.Month)
                return age - 1;
            if (DateTime.Today.Month == _dateOfBirth.Month && DateTime.Today.Day < _dateOfBirth.Day)
                return age - 1;
            return age;
        }

        private string GetEasternZodiac()
        {
            return ChineeseZodiacs[_dateOfBirth.Year % 12];
        }

        private string GetWesternZodiac()
        {
            //You should alway generate default case
            switch (_dateOfBirth.Month)
            {
                case 1:
                    if (_dateOfBirth.Day >= 20)
                        return "Aquarius";
                    if (_dateOfBirth.Day <= 19)
                        return "Capricorn";
                    break;
                case 2:
                    if (_dateOfBirth.Day >= 19)
                        return "Pisces";
                    if (_dateOfBirth.Day <= 18)
                        return "Aquarius";
                    break;
                case 3:
                    if (_dateOfBirth.Day >= 21)
                        return "Aries";
                    if (_dateOfBirth.Day <= 20)
                        return "Pisces";
                    break;
                case 4:
                    if (_dateOfBirth.Day >= 20)
                        return "Taurus";
                    if (_dateOfBirth.Day <= 19)
                        return "Aries";
                    break;
                case 5:
                    if (_dateOfBirth.Day >= 21)
                        return "Gemini";
                    if (_dateOfBirth.Day <= 20)
                        return "Taurus";
                    break;
                case 6:
                    if (_dateOfBirth.Day >= 21)
                        return "Cancer";
                    if (_dateOfBirth.Day <= 20)
                        return "Taurus";
                    break;
                case 7:
                    if (_dateOfBirth.Day >= 23)
                        return "Leo";
                    if (_dateOfBirth.Day <= 22)
                        return "Cancer";
                    break;
                case 8:
                    if (_dateOfBirth.Day >= 23)
                        return "Virgo";
                    if (_dateOfBirth.Day <= 22)
                        return "Leo";
                    break;
                case 9:
                    if (_dateOfBirth.Day >= 23)
                        return "Libra";
                    if (_dateOfBirth.Day <= 22)
                        return "Virgo";
                    break;
                case 10:
                    if (_dateOfBirth.Day >= 23)
                        return "Scorpio";
                    if (_dateOfBirth.Day <= 22)
                        return "Libra";
                    break;
                case 11:
                    if (_dateOfBirth.Day >= 22)
                        return "Sagittarius";
                    if (_dateOfBirth.Day <= 21)
                        return "Scorpio";
                    break;
                case 12:
                    if (_dateOfBirth.Day >= 22)
                        return "Capricorn";
                    if (_dateOfBirth.Day <= 21)
                        return "Sagittarius";
                    break;
                default:
                    throw new ArgumentException();
            }
            return "";
        }
    }
}
