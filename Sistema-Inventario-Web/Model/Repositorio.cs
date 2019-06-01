using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Repositorio : Repositorio2.Repositorio, IRepositorio, IDisposable
    {
        public Repositorio(bool autoDetectChangesEnabled = false, bool proxiCreationEnabled = false) :
           base(new Entidades(), autoDetectChangesEnabled, proxiCreationEnabled)
        {
        }
    }
}
