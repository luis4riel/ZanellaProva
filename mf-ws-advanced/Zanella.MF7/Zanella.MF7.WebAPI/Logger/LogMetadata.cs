using System;
using Zanella.MF7.WebAPI.Exceptions;

namespace Zanella.MF7.WebAPI.Logger
{
    public class LogMetadata
    {

        public string RequestUri { get; set; }

        public string RequestMethod { get; set; }

        public DateTime RequestTimestamp { get; set; }

        public int? ResponseStatusCode { get; set; }

        public DateTime ResponseTimestamp { get; set; }

        public ExceptionPayload ResponseExceptionPayLoad { get; set; }
    }
}