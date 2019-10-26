using System;
using System.Text.RegularExpressions;

namespace ContactsApp.Model
{
    /// <summary>
    ///     Класс Person, хранящий информацию о имени, номера, почты,
    ///     vkId контакта.
    /// </summary>
    [Serializable]
    public class Contact
    {
        /// <summary>
        ///     Фамилия контакта
        /// </summary>
        private string _surname;
        /// <summary>
        ///     Имя контакта
        /// </summary>
        private string _name;
        /// <summary>
        ///     Дата рождения контакта
        /// </summary>
        private DateTime _birthday;
        /// <summary>
        ///     Номер контакта
        /// </summary>
        private string _phone;
        /// <summary>
        ///     Почта контакта
        /// </summary>
        private string _mail;
        /// <summary>
        ///     VkontakteId контакта 
        /// </summary>
        private string _vkId;
        

        /// <summary>
        ///     Создает экземпляр класса Person
        /// </summary>
        public Contact(string surname, string name, DateTime birthday, string phone, 
            string mail, string vkId)
        {
            Surname = surname;
            Name = name;
            Birthday = birthday;
            Phone = phone;
            Mail = mail;
            VkId = vkId;
        }

        /// <summary>
        ///     Возвращает и задает фамилию пользователя.
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                var pattern = "^[A-Z][a-z]{0,30}$";
                if (Regex.IsMatch(value, pattern))
                {
                    _surname = value;
                }
                else
                {
                    throw new ArgumentException(nameof(_surname));
                }
            }
        }
        /// <summary>
        ///     Возвращает и задает имя пользователя.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                var pattern = "^[A-Z][a-z]{0,30}$";

                if (Regex.IsMatch(value, pattern))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException(nameof(_name));
                }
            }
        }

        /// <summary>
        ///     Возвращает и задает дату рождения пользователя.
        /// </summary>
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                if (value < DateTime.Now)
                {
                    _birthday = value;
                }
                else
                {
                    throw new ArgumentException(nameof(_birthday));
                }
            }
        }

        /// <summary>
        ///     Возвращает и задает номер пользователя.
        /// </summary>
        public string Phone
        {
            get => _phone;
            set
            {
                var pattern = @"\+7\(\d{3}\)\d{3}-\d{2}-\d{2}";

                if (Regex.IsMatch(value, pattern))
                {
                    _phone = value;
                }
                else
                {
                    throw new ArgumentException(nameof(_phone));
                }
            }
        }

        /// <summary>
        ///     Возвращает и задает почту пользователя.
        /// </summary>
        public string Mail
        {
            get => _mail;
            set
            {
                var pattern =
                    @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

                if (Regex.IsMatch(value, pattern))
                {
                    _mail = value;
                }
                else
                {
                    throw new ArgumentException(nameof(_mail));
                }
            }
        }

        /// <summary>
        ///     Возвращает и задает vkid пользователя.
        /// </summary>
        public string VkId
        {
            get => _vkId;
            set
            {
                var pattern = @"\w+";
                if (Regex.IsMatch(value, pattern))
                {
                    _vkId = value;
                }
                else
                {
                    throw new ArgumentException(nameof(_vkId));
                }
            }
        }
    }
}