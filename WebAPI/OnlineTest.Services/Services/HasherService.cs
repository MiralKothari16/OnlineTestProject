using OnlineTest.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.Services
{
    public class HasherService :IHasherService
    {
        public string Hash(string input)    
        {
            //byte[] encData_byte = new byte[input.Length];
            //encData_byte = System.Text.Encoding.UTF8.GetBytes(input);
            //string encodedData = Convert.ToBase64String(encData_byte);
            //return encodedData;

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            string hashString = string.Empty;
            using (var sha = SHA512.Create())
            {
                byte[] hash = sha.ComputeHash(inputBytes);
                foreach (byte x in hash)
                {
                    hashString += String.Format("{0:x2}", x);
                }
            }
            return hashString;
        }
    }
}
