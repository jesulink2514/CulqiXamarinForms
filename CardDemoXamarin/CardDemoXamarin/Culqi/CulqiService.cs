using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardDemoXamarin.Culqi
{
    [Headers("Authorization: Bearer XXX")]
    public interface ICulqiService
    {
        [Post("/v2/tokens")]
        Task<HttpResponseMessage> CreateToken(CulqiPaymentRequest request, CancellationToken token);
    }
}
