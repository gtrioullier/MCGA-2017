using ASF.UI.WbSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.WbSite.ServicesReferenced;

namespace ASF.UI.WbSite.Controllers
{
    public class PagosController : Controller
    {
        // GET: Pagos
        public ActionResult Pagar(Guid rowid, float Importe)
        {
            var model = new PagoModel();
            model.rowid = rowid;
            model.Importe = Importe;
            return View(model);
        }
        // POST: Pago/Create
        [HttpPost]
        public ActionResult Pagar(PagoModel pago, Guid rowid)
        {

            //Después de instalar el webservice
            try
            {
                var lista = new List<ASF.Entities.Product>();
                WebService1SoapClient compra = new WebService1SoapClient();
                pago.number = pago.number.Replace(" ", "");
                pago.expiry = pago.expiry.Replace(" / ", "");
                string fechavence = "20" + pago.expiry.Substring(2, 2) + "-" + pago.expiry.Substring(0, 2);
                long n1 = Convert.ToInt64(pago.number);
                string res = compra.ValidarTarjeta(n1, pago.Importe, fechavence, pago.cvc);

                switch (res)
                {
                    case "Operación realizada con éxito.": { res = "Operación realizada con éxito."; break; }
                    case "Error: Saldo insuficiente.": { res = "Error: Saldo insuficiente."; break; }
                    case "Error: Tarjeta no válida.": { res = "Error: Tarjeta no válida."; break; }
                    case "Error: Codigo de Seguridad incorrecto.": { res = "Error: Codigo de Seguridad incorrecto."; break; }
                    case "Error: Tarjeta Vencida.": { res = "Error: Tarjeta Vencida."; break; }
                    default: { res = "Error: Servicio no disponible."; break; }
                }

                ViewBag.result = res;

                if (res == "Operación realizada con éxito.") {
                    //con el id de la orden, cambio el status de la orden
                    var order = new ASF.Entities.Order();
                    var cp = new ASF.UI.Process.OrderProcess();
                 

                    order = cp.Find(rowid);

                    order.State = "Approved";

                    cp.Edit(order);

                    //con el id de orden, me traigo todas la líneas de la orden, y me quedo con el productId.
                    //tendrá una lista de produtid.... que arman una lista de productos que debo mostrar en resultado
                    //para que el usuario rankee
                    var cpd = new ASF.UI.Process.OrderDetailProcess();
                    var details = cpd.SelectList().Where(d => d.OrderId == order.Id).ToList();
                    
                    foreach (var detail in details)
                    {
                        var cpp = new ASF.UI.Process.ProductProcess();
                        var product = cpp.SelectList().Where(p => p.Id == detail.ProductId).FirstOrDefault();
                        lista.Add(product);
                    }
                }

                return View("result", lista);
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { error = 503 });
            }
        }

        //return View(); 
    }
}