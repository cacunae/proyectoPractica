using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace AutoToken
{
    public class Query
    {

        public void RealizarQuery(string token)
        {
            //Generando petición para el query

            var clientQuery = new RestClient("https://us.coresuite.com/api/query/v1?account=marsol&company=marsol&clientIdentifier=COR_NON_NONE&dtos=Activity.37;BusinessPartner.22;ChecklistInstance.18;ChecklistInstanceElement.16;ChecklistTemplate.19;Person.24;ServiceAssignment.28;ServiceCall.26");
            clientQuery.Timeout = -1;
            var requestQuery = new RestRequest(Method.POST);
            requestQuery.AddHeader("Authorization", "Bearer " + token);
            requestQuery.AddHeader("Content-type", "application/json");
            requestQuery.AddHeader("x-Client-Version", "1.0");
            requestQuery.AddHeader("cache-control", "no-cache");
            requestQuery.AddHeader("x-Client-ID", "TI2021");
            //Para insertar todos los datos obtenidos se elimina el parámetro "LIMIT"
            requestQuery.AddParameter("application/json", "{\"query\":\"SELECT sc.code, p.emailAddress,p.mobilePhone,cte.title,cte.value,sc.code,bp.name,a.code,a.startDateTime,p.userName,p.lastName, ct.name,cte.elementId, cte.title, cte.value, cte.checklistInstance, cte.checklistTemplate, cte.createDateTime, cte.id, cte.updateAuthor, cte.updated FROM ChecklistInstanceElement cte JOIN ChecklistInstance ci ON cte.checklistInstance=ci.id JOIN ChecklistTemplate ct ON ci.template=ct.id JOIN Activity a ON ci.object.objectId=a.id JOIN ServiceCall sc ON a.object.objectId=sc.id JOIN BusinessPartner bp ON bp.id=sc.businessPartner JOIN ServiceAssignment sa  ON sa.activity=a.id JOIN Person p ON sa.technician=p.id WHERE  a.startDateTime >= '2021-02-01' LIMIT 10  \"}", ParameterType.RequestBody);
            //Peticion construida y se envia Query al servidor


            ResponseModel.Root datosQuery = new ResponseModel.Root();
            IRestResponse responseQuery = clientQuery.Execute(requestQuery);
            datosQuery = JsonConvert.DeserializeObject<ResponseModel.Root>(responseQuery.Content);
            //Deserializando respuesta y construyendo objetos
            try
            {

                //Se inicia ciclo para recorrer los datos extraídos
                foreach (var datos in datosQuery.data)
                {
                    ResponseModel.Datum resultado = new ResponseModel.Datum();
                    {
                        resultado.sc = datos.sc;
                        resultado.sc.code = datos.sc.code;

                        resultado.p = datos.p;
                        resultado.p.lastName = datos.p.lastName;
                        resultado.p.emailAddress = datos.p.emailAddress;
                        resultado.p.mobilePhone = datos.p.mobilePhone;
                        resultado.p.userName = datos.p.userName;

                        resultado.cte = datos.cte;
                        resultado.cte.elementId = datos.cte.elementId;
                        resultado.cte.checklistTemplate = datos.cte.checklistTemplate;
                        resultado.cte.checklistInstance = datos.cte.checklistInstance;
                        resultado.cte.updateAuthor = datos.cte.updateAuthor;
                        resultado.cte.id = datos.cte.id;
                        resultado.cte.title = datos.cte.title;
                        resultado.cte.updated = datos.cte.updated;
                        resultado.cte.value = datos.cte.value;
                        resultado.cte.createDateTime = datos.cte.createDateTime;

                        resultado.bp = datos.bp;
                        resultado.bp.name = datos.bp.name;

                        resultado.a = datos.a;
                        resultado.a.code = datos.a.code;
                        resultado.a.startDateTime = datos.a.startDateTime;

                        resultado.ct = datos.ct;
                        resultado.ct.name = datos.ct.name;
                    }

                    //Se filtran los datos recibidos eliminando las abreviaturas de las tablas y creando un objeto 
                    //moldeado a la tabla SFS_Checklist

                    DeserializedResponse deserialized = new DeserializedResponse();
                    deserialized.code = resultado.sc.code;
                    deserialized.lastName = resultado.p.lastName;
                    deserialized.emailAddress = resultado.p.emailAddress;
                    deserialized.mobilePhone = resultado.p.mobilePhone;
                    deserialized.userName = resultado.p.userName;
                    deserialized.elementId = resultado.cte.elementId;
                    deserialized.checklistTemplate = resultado.cte.checklistTemplate;
                    deserialized.checklistInstance = resultado.cte.checklistInstance;
                    deserialized.updateAuthor = resultado.cte.updateAuthor;
                    deserialized.id = resultado.cte.id;
                    deserialized.title = resultado.cte.title;
                    deserialized.updated = resultado.cte.updated;
                    deserialized.value = resultado.cte.value;
                    deserialized.createDateTime = resultado.cte.createDateTime;
                    deserialized.cardName = resultado.bp.name;
                    deserialized.Acode = resultado.a.code;
                    deserialized.AstartDateTime = resultado.a.startDateTime;
                    deserialized.name = resultado.ct.name;

                    //Se llama a los metodos creados en la BD y se insertan los datos filtrados.
                    MetodosBD metodos = new MetodosBD();

                    if (metodos.Insertar(deserialized))
                    {
                        Console.WriteLine("Datos Insertados");

                    }
                    else
                    {
                        Console.WriteLine("Ha ocurrido un problema");

                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Ha ocurrido un error" + ex.Message);

            }
        }
    }      


    
}
