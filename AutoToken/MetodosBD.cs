using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoToken
{
    class MetodosBD
    {

        
        public static int globalId = 1;
        //Metodo Id Autoincremental
        static int generarId()
        {
            return globalId++;
        }

        //Metodo de inserción de datos
        public bool Insertar(DeserializedResponse datos)
        {
            try
            {
                using (CumpLlamEntities1 bd = new CumpLlamEntities1())
                {
                    SFS_Checklist resultado = new SFS_Checklist();
                    resultado.id = generarId();
                    resultado.code = Convert.ToInt32(datos.code);

                    resultado.nombreTecnico = datos.lastName;
                    resultado.emailTecnico = datos.emailAddress;
                    resultado.movil = Convert.ToInt64(datos.mobilePhone);
                    resultado.usuarioTecnico = datos.userName;

                    resultado.elementoChecklist = datos.elementId;
                    resultado.checklistTemplate = datos.checklistTemplate;
                    resultado.checklistInstance = datos.checklistInstance;
                    resultado.checklistUpdAutor = datos.updateAuthor;
                    resultado.checklistId = datos.id;
                    resultado.etiquetaChecklist = datos.title;
                    resultado.fechaActualiza = datos.updated;
                    resultado.comentarioChecklist = datos.value;
                    resultado.fechaCreacion = datos.createDateTime;

                    resultado.cardName = datos.name;

                    resultado.clgCode = Convert.ToInt32(datos.Acode);
                    resultado.fechaInicioActividad = datos.AstartDateTime;

                    resultado.checklistName = datos.name;

                    bd.SFS_Checklist.Add(resultado);
                    bd.SaveChanges();

                }
                    
                return true;

            }
            catch
            {

                return false;
            }

            
        }

    }
}
