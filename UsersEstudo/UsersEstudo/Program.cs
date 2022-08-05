using System;
using UsersStudy.Database;
using UsersStudy.Validations;

namespace UsersEstudo
{
    public class Program
    {
        public static int GetAge()
        {
            return Convert.ToInt32(TextAndGetAnswer("How old are you?  "));
        }

        public static void Main(string[] args)
        {
            var usersRepository = new UsersRepository();
            var userValidation = new UserValidation();

            while (true)
            {
                Console.Clear();
                var registerAnswer = Convert.ToInt32(TextAndGetAnswer("Do you want to register? 1 for Yes and 2 for No!"));
                
                if (registerAnswer == 1)
                {
                    var user = new Users();
                    user.Name = TextAndGetAnswer("What is your name?  ").ToString();
                    user.Age = GetAge();
                    user.Phone = TextAndGetAnswer("What is your phone number?  ").ToString();
                    user.Mail = TextAndGetAnswer("What is your Mail?  ").ToString();

                    userValidation.ProcessUserValidation(user);
                  
                    var result = usersRepository.InsertUsers(user);
                    if (result == true)
                        Console.WriteLine("Registered successfully!");
                    else
                    {
                        Console.WriteLine("Error in registration!");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Bye bye!");
                    Console.ReadLine();
                }
            }
        }

        private static object TextAndGetAnswer(string message)
        {
            Console.WriteLine(message);
            string answer = Console.ReadLine();
            return answer;
        }
    }
}
