using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPVService.Data;
using TPVService.Entities;

namespace TPVService.Logic
{
    public class LUsuarios
    {
        public void validaUsuario(Usuario user, ref ETransactionResult result)
        {
            DA_Usuario db = new DA_Usuario();
            var item = db.usuarios_Get(user, ref result);

            if(result.result != 0)
            {
                result.message = "Usurario o Contraseña incorrecta.";
            }
            else
            {
                if(user.passwd.Trim() != item.passwd.Trim())
                {
                    result.message = "Usurario o Contraseña incorrecta.";
                    result.result = 1;
                }
                else if(!(bool)item.estatus)
                {
                    result.message = "Usurario Inactivo.";
                    result.result = 1;
                }
                else if(item.roll != "ADMIN")
                {
                    result.message = "Su Usuario no tiene privilegios para esta aplicación.";
                    result.result = 1;
                }
            }
        }
        public Usuario getUsuraio(Usuario user, ref ETransactionResult result)
        {
            DA_Usuario db = new DA_Usuario();
            var item = db.usuarios_Get(user, ref result);

            if (result.result != 0)
            {
                result.message = "El Usuario no Existe.";
            }

            return item;
        }
    }
}