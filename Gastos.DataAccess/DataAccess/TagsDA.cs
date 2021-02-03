using Gastos.DataAccess.Interfaces;
using Gastos.Infrastructure.Models;
using System;

namespace Gastos.DataAccess
{
    public class TagsDA : ITagsDA
    {
        public GastosContext _gastosContext;
        public TagsDA(GastosContext gastosContext)
        {
            this._gastosContext = gastosContext;
        }

        public object BuscarTagsUsuario(string usuarioId)
        {
            try
            {
                
            }catch(Exception ex)
            {
                return new object();
            }
        }
    }
}
