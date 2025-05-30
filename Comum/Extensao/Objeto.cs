using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Son.Comum.Extensao
{
    public static class Objeto
    {
        public static void CopiarPara(this Object pObjetoOrigem, Object pObjetoDestino)
        {
            PropertyInfo[] propriedadesOrigem = pObjetoOrigem.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);

            foreach (var propriedade in propriedadesOrigem)
            {
                PropertyInfo campoDestino = pObjetoDestino.GetType().GetProperty(propriedade.Name);

                if (campoDestino != null)
                    campoDestino.SetValue(pObjetoDestino, propriedade.GetValue(pObjetoOrigem));
            }

        }
    }
}
