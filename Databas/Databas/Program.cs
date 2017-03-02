using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User;

public class Program
{
    UserConnect currUser;
    static void Main()
    {
        Console.WriteLine("1.Log In\n2.Create new user");
        int val = ReadInt();
        switch (val)
        {
            case 1:
                break;
            case 2:
                Console.Write("UserName:");
                string user = ReadString();
                Console.Write("Password:");
                string pass = ReadString();
                try
                {
                    UserConnect connect = new UserConnect(1,user, pass);
                    connect.CreateNewUser(user,pass);
                    Console.WriteLine("Succefully created user");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    
                }
                break;
            default:
                Console.WriteLine("Mellan 1-2s");
                break;
        }
        Console.ReadLine();

    }
    static int ReadInt()
    {
        while (true)
        {
            int readInteger;

            while (!int.TryParse(Console.ReadLine(), out readInteger))
                Console.WriteLine("Endast siffror");

            if (readInteger < 0)
                Console.WriteLine("Endast positiva tal");
            
            else
                return readInteger;
        }
    }
    static string ReadString()
    {
        string temp="";

        while (string.IsNullOrEmpty(temp)||temp.Any(ch=>!Char.IsLetterOrDigit(ch)))
        {
            temp = Console.ReadLine();
        }
        return temp;
    }
}
