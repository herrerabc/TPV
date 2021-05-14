﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dulceria.Entidades;
using Dulceria.AccesoDatos;

namespace Dulceria.Logica
{
    public class LMovimiento : ICatalogos
    {
        public void Delete(object obj, ref ETransactionResult result)
        {
            DaMovimiento daLista = new DaMovimiento();
            daLista.Movimiento_Delete((EMovimiento)obj, ref result);
        }

        public object Get(object obj, ref ETransactionResult result)
        {
            DaMovimiento daLista = new DaMovimiento();
            return daLista.Movimiento_Get((EMovimiento)obj, ref result);
        }

        public List<object> GetAll(ref ETransactionResult result)
        {
            DaMovimiento daLista = new DaMovimiento();
            return daLista.Movimiento_GetAll(ref result).ToList<object>();
        }

        public object Insert(object obj, ref ETransactionResult result)
        {
            DaMovimiento daLista = new DaMovimiento();
            return daLista.Movimiento_Insert((EMovimiento)obj, ref result);
        }

        public void Update(object obj, ref ETransactionResult result)
        {
            DaMovimiento daLista = new DaMovimiento();
            daLista.Movimiento_Update((EMovimiento)obj, ref result);
        }
    }
}
