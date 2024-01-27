using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace KwsBlobProcess.Function
{
    public class ProcessBlob
    {
        [FunctionName("ProcessBlob")]
        public static async Task Run(
            [BlobTrigger("input/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, 
            [Blob("output/{name}", FileAccess.Write, Connection = "AzureWebJobsStorage")]Stream outputBlob,
            ILogger log)
        {
            await myBlob.CopyToAsync(outputBlob);
        }
    }
}
