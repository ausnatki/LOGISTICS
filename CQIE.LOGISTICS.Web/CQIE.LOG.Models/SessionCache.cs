using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models
{
    [Table("TB_SessionCache")]

    public class SessionCache
    {
        public int nid { get; set; }
        public string Id { get; set; }
        public byte[] Value { get; set; }
        public DateTime ExpiresAtTime { get; set; }
        public long? SlidingExpirationSeconds { get; set; }
        public DateTime? AbsoluteExpiration { get; set; }
    }
}
