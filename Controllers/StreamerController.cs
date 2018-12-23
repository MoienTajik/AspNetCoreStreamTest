using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;

namespace TestStream.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StreamerController : ControllerBase
    {
        const string Filename = @"G:\Music\abc.mp3";

        [HttpGet("Stream")]
        public IActionResult Stream()
        {
            byte[] fileData;

            using (FileStream fs = System.IO.File.OpenRead(Filename))
            {
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {
                    fileData = binaryReader.ReadBytes((int)(fs.Length * 0.4));
                }
            }

            MemoryStream stream = new MemoryStream(fileData);
            return new FileStreamResult(stream, new MediaTypeHeaderValue("audio/mpeg").MediaType);
        }
    }
}