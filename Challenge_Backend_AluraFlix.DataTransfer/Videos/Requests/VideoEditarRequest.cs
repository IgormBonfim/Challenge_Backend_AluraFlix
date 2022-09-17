using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Videos.Requests
{
    public class VideoEditarRequest
    {
        public int? idVideo { get; set; }
        public string? TituloVideo { get; set; }
        public string? DescVideo { get; set; }
        public string? UrlVideo { get; set; }
    }
}
