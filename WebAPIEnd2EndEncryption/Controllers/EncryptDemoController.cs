using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIEnd2EndEncryption.Models;
using WebAPIEnd2EndEncryption.SHA512EncryptionEngine;

namespace WebAPIEnd2EndEncryption.Controllers
{
    [RoutePrefix("api/v1")]
    public class EncryptDemoController : ApiController
    {
        [HttpPost]
        [Route("customer/payment")]
        public HttpResponseMessage PaymentUpdate([FromBody] PaymentUpdateRequestModel model)
        {
            try
            {
                if (model == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        error = true,
                        message = "Bad Request"
                    });

                }

                string rawValues = $"{model.customerName}{model.referenceID}{model.transReference}{model.phoneNumber}";
                string expectedSha512Hash = EncryptionHelper.EncryptSha512(rawValues);

                if (!expectedSha512Hash.ToUpper().Equals(model.hash.ToUpper()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        error = true,
                        message = "Invalid hash detected"
                    });
                }

                var payment = PaymentRepository.GetPayments().FirstOrDefault(m=>m.ReferenceID==model.referenceID);
                if (payment == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        error = true,
                        message = "Invalid Reference ID"
                    });
                }

                string responseValues = $"{payment.Currency}{payment.CustomerName}{payment.PhoneNumber}{payment.TotalAmount}{payment.ReferenceID}{payment.TransReference}";
                string expectedresponseSha512Hash = EncryptionHelper.EncryptSha512(responseValues);

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    error = false,
                    message="success",
                    payment =payment,
                    hash= expectedresponseSha512Hash
                });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    error = true,
                    message = "Application Exception :: " + ex.Message
                });
            }
        }


    }
}
