using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Methods
{
    public static class UserMethods
    {

        /// <summary>
        /// Verifica si el Email es valido
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            try
            {
                if (email.Contains("@") && email.Contains(".com"))
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex; 
            }

        }

    }
}
