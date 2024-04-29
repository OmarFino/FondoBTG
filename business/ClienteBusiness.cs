using FondoBTG.Models;
using FondoBTG.Repositories;
using FondoBTG.Utilities;
using MongoDB.Bson;

namespace FondoBTG.business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private IClienteCollection clienteCollection = new ClienteCollection();
        private IFondoCollection fondoCollection = new FondoCollection();

        public async Task<Response> GetClienteById(string id)
        {
            try
            {
                var result = await clienteCollection.GetClienteById(id);
                if (result == null)
                {
                    return new Response(ResponseCode.DATA_NOT_FOUND.ToString(), ResponseMessage.DATA_NOT_FOUND.ToString(), result);
                }
                return new Response(ResponseCode.OK.ToString(), ResponseMessage.OK.ToString(), result);

            }
            catch (Exception ex)
            {

                return new Response(ResponseMessage.INTERNAL_SERVER_ERROR.ToString(), ResponseMessage.INTERNAL_SERVER_ERROR.ToString(), ex.Message);
            }
        }

        public async Task<Response> GetPrimerCliente()
        {
            try
            {
                var result = await clienteCollection.GetPrimerCliente();
                if (result == null)
                {
                    return new Response(ResponseCode.DATA_NOT_FOUND.ToString(), ResponseMessage.DATA_NOT_FOUND.ToString(), result);
                }
                return new Response(ResponseCode.OK.ToString(), ResponseMessage.OK.ToString(), result);

            }
            catch (Exception ex)
            {

                return new Response(ResponseMessage.INTERNAL_SERVER_ERROR.ToString(), ResponseMessage.INTERNAL_SERVER_ERROR.ToString(), ex.Message);
            }
        }

        public async Task<Response> InsertCliente(Cliente cliente)
        {
            try
            {
                await clienteCollection.InsertCliente(cliente);
                return new Response(ResponseCode.CREATED.ToString(), ResponseMessage.CREATED.ToString(), "Cliente creado");

            }
            catch (Exception ex)
            {

                return new Response(ResponseMessage.INTERNAL_SERVER_ERROR.ToString(), ResponseMessage.INTERNAL_SERVER_ERROR.ToString(), ex.Message);

            };
        }

        //public async Task<Response> DeleteFondoCliente(string identification, string id)
        //{
        //    try
        //    {
        //        var cliente = await clienteCollection.DeleteFondoCliente(identification, id);
                
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task<Response> AddFondoCliente(string id, string idFondo, double valor)
        {
            try
            {

                var cliente = await clienteCollection.GetClienteById(id);
                if (cliente != null)
                {
                    var fondo = await fondoCollection.GetFondoById(idFondo);

                    if (cliente.Balance < fondo.Minimum_amount || valor < fondo.Minimum_amount || cliente.Balance < valor)
                    {
                        return new Response(ResponseCode.CONFLICT.ToString(), ResponseMessage.CONFLICT.ToString(), "saldo minimo para vincularse al fondo: " + fondo.Name +" es de: " + fondo.Minimum_amount);

                    }

                    var newFondoCliente = new FondoCliente
                    {
                        Nombre = fondo.Name,
                        Valor = valor,
                        FechaRegistro = DateTime.Now,
                        State = "A",
                        Id= ObjectId.GenerateNewId().ToString(),
                        
                    };
                    var result = await clienteCollection.AddFondoCliente(cliente.Identification, newFondoCliente);


                    if (result)
                    {
                        await clienteCollection.UpdateCliente(cliente.Identification, "Balance", (cliente.Balance - valor));
                        return new Response(ResponseCode.CREATED.ToString(), ResponseMessage.CREATED.ToString(), "Fondo Agregado");
                    }
                    return new Response(ResponseCode.CONFLICT.ToString(), ResponseMessage.CONFLICT.ToString(), "Error al agregar el Fondo");
                }
                return new Response(ResponseCode.DATA_NOT_FOUND.ToString(), ResponseMessage.DATA_NOT_FOUND.ToString(), "No se encontro ningun client con el ID: " + id);


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
