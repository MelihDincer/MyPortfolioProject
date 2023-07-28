using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WriterMessage
    {
        [Key]
        public int WriterMessageID { get; set; }
        public string Sender { get; set; } //Gönderen : mail olarak tutulacak
        public string Receiver { get; set; } //Alıcı : mail olarak tutulacak
        public string SenderName{ get; set; }
        public string ReceiverName{ get; set; }
        public string Subject { get; set; } //Konu
        //public string Content { get; set; }
        public string MessageContent { get; set; }
        public DateTime Date { get; set; }
    }
}
