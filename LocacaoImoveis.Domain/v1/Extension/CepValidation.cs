using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoImoveis.Domain.v1.Extension
{
    public class CepValidation
    {

        public static bool CepValidationExtension(string cep)
        {
            string _cep = cep.Replace("-", "").Replace(" ", "");
            if(_cep.Length != 8) return false;  
            try
            {
                int integerCep = Convert.ToInt32(_cep);
            }
            catch (Exception ex)
            {
                return false;
            }
            if (_cep.Length != 8) return false;

            return true;    
        }

        public static string cepFormatted(string cep)
        {
            return cep.Replace("-", "").Replace(" ", "");
        }


    }
}
