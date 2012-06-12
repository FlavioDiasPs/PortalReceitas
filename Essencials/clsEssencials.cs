using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using System.Net;
using System.IO;

namespace Essencials
{
    public class clsEssencials
    {
        //destructor
        ~clsEssencials()
        {
            System.GC.Collect();
        }

        //Criar função para utilizar a API
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

        public bool verificarConexao()
        {
            return IsConnectedToInternet();
        }

        public string removerAcentos(string texto)
        {
            string s = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString();
        }

        public string pegarCodigoFonte(string urlCompleta)
        {
            string textoInteiro;

            //faz a chamada
            Uri uri = new Uri(urlCompleta);
            WebRequest request = WebRequest.Create(uri);
            WebResponse response = request.GetResponse();

            //faz a leitura
            Stream strm = response.GetResponseStream();
            StreamReader reader = new StreamReader(strm);

            //le todo o texto
            textoInteiro = reader.ReadToEnd();
            reader.Close();

            return textoInteiro;
        }
    }
}
