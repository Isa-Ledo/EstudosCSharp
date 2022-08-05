using System;
using System.Linq;
using UsersStudy.Database;

namespace UsersStudy.Validations
{
    public class UserValidation
    {

        public void ProcessUserValidation(Users user)
        {
            if (!IsAgeValid(user.Age))
                throw new Exception("You are 18 years old, go to mommy");

            if (!IsPhoneValid(user.Phone))
                throw new Exception("Invalid phone");


            if (!IsEmailValid(user.Mail))
                throw new Exception("Invalid mail");

            IsInfoDuplicated(user.Mail, user.Phone);
        }

        public bool IsInfoDuplicated(string mail, string phone)
        {
            var usersRepository = new UsersRepository();
            var users = usersRepository.SearchUsers();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Mail == mail)
                    throw new Exception("Invalid mail");
                else if (users[i].Phone == phone)
                    throw new Exception("Invalid phone");
            }
            return false;
        }

        public bool IsAgeValid(int age)
        {
            return age >= 18;
        }

        public bool IsPhoneValid(string phone)
        {
            var phoneWithoutSpecialCharacters = phone.Replace(" ", "").Replace("(", "").Replace(")", "");
            return phoneWithoutSpecialCharacters.Length == 11 || phoneWithoutSpecialCharacters.Length == 10;
        }

        public bool IsEmailValid(string mail)
        {
            var parts = mail.Split("@");

            if(parts.Length != 2)
                return false;
           
            if (parts.First().Contains("hotmail.com") || 
                parts.First().Contains("gmail.com.br") || 
                parts.First().Contains("gmail.com") || 
                parts.First().Contains("hotmail.com.br"))
                return false;

            if(parts.Last().Contains("hotmail.com") || parts.Last().Contains("hotmail.com.br") 
                || parts.Last().Contains("gmail.com.br") || parts.Last().Contains("gmail.com"))
                return true;

            var usersRepository = new UsersRepository();

            var userFound = usersRepository.SearchUserByEmail(mail);

            if(userFound != null)
                throw new Exception("Mail already exist in the database.");

            return false;
        }
    }
}
