using Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio2
{
    public class RepositorioTrabajo : Repositorio,  UnidadTrabajo, IDisposable
    {
        public RepositorioTrabajo(DbContext context, bool autoDetectChangesEnabled = false, bool proxiCreationEnabled = false) :
           base(context, autoDetectChangesEnabled, proxiCreationEnabled)
        {

        }
        public int Save()
        {
            int Result = 0;
            try
            {
                Result = Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                string strError = "";
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        strError += string.Format("Prperty:{0} Error{1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
            return Result;

        }
        protected override int TrySaveChanges()
        {
            return 0;
        }
    }
}
