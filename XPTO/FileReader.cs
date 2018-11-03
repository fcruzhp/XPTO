using System;
using System.IO;
using System.Linq;

namespace XPTO
{
    public class FileReader
    {
        public static Tuple<XPTOContext, bool> OpenFile(String path)
        {
            String fileContents;

            using (StreamReader reader = new StreamReader(path))
            {
                fileContents = reader.ReadToEnd();
            }

            if (string.IsNullOrEmpty(fileContents))
            {
                return null;
            }

            XPTOContext context = new XPTOContext();
            bool IsPessoas = false;
            foreach (string s in fileContents.Split(';'))
            {
                var str = s.Split(',');

                if (str.Length == 7)
                {
                    if(context.Pessoas.FirstOrDefault(p=>p.Id == Convert.ToInt32(str[0])) != null)
                    {
                        Pessoa p = context.Pessoas.Create();
                        p.Id = Convert.ToInt32(str[0]);
                        p.Nome = str[1];
                        p.SobreNome = str[2];
                        p.DataNascimento = Convert.ToDateTime(str[3]);
                        p.Sexo = str[4];
                        p.Email = str[5];
                        p.Booleano = Convert.ToBoolean(str[6]);
                        context.Pessoas.Add(p);
                    }

                    IsPessoas = true;
                }

                else if (str.Length == 3)
                {
                    Produto p = new Produto
                    {
                        Coluna1 = Convert.ToInt32(str[0]),
                        Coluna2 = Convert.ToInt32(str[1]),
                        NomeProduto = str[2]
                    };
                    context.Produtos.Add(p);
                }
            }
            
            return Tuple.Create(context, IsPessoas);
        }
    }    
}
