using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatos
{
   public  class Dto:EnviarDatos.EnvioDatos,IDisposable,DatosInventarios
    {
        public Dto(bool autoDetectChangesEnabled = false, bool proxiCreationEnabled = false) :
           base(new Entidades(), autoDetectChangesEnabled, proxiCreationEnabled)
        {
        }
    }
}
