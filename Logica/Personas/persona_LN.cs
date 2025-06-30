using Datos.Datos;
using Modelos.personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Personas
{
    public class persona_LN
    {
        private readonly Contexto bd;
        #region CRUD
        public persona_LN()
        {
            bd = new Contexto();
        }
        public bool AgregarNuevonombrepersonaynuevafrase(personas_VM datospersonas, out string? errorMessage)
        {
            using (var transaction = bd.Database.BeginTransaction())
            {
                try
                {

                    

                    // Insertar en la tabla Colaboradores
                    var nuevapersonayfrase = new Persona
                    {
                        Nombre = datospersonas.Nombre,
                        Apellido = datospersonas.Apellido,
                        Edad = datospersonas.Edad,
                        Frase = datospersonas.Frase,
                        Estado = true
                        
                    };
                    bd.Persona.Add(nuevapersonayfrase);


                    bd.SaveChanges();
                    // Confirmar la transacción
                    transaction.Commit();

                    errorMessage = null;  // No hay error, establecer el mensaje a null
                    return true;
                }
                catch (Exception ex)
                {
                    // Manejar errores y revertir la transacción
                    transaction.Rollback();
                    errorMessage = ex.Message;
                    return false;
                }
            }
        }


        #endregion

        #region consultar
        public bool obtenerlistadepersonayfrase(ref List<personas_VM> Listapersonayfrase, out string? errorMessage)
        {
            try
            {
                // Utilizar LINQ para seleccionar los campos necesarios y mapearlos a Roles_VM
                Listapersonayfrase = (from PER in bd.Persona
                                       select new personas_VM
                                      {
                                          Id = PER.Id,
                                          Nombre = PER.Nombre,
                                          Apellido = PER.Apellido,
                                          Edad = PER.Edad,
                                          Frase = PER.Frase,
                                      }).ToList();
                errorMessage = null;  // No hay error, establecer el mensaje a null
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
        #endregion

    }
}

