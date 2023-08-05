using EntityLayer.Concrete;
using System;

namespace NetCore_Proje.Models
{
    public class MessageViewModel
    {
        public int MessageID { get; set; }
        public WriterMessage Message { get; set; }
        public string SenderImage { get; set; }
        public string SenderName { get; set; }
        public DateTime Date { get; set; }
    }
}