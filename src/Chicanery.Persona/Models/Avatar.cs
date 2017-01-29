namespace Chicanery.Persona.Models
{
    public class Avatar
    {
        public int Id { get; set; }
        public string MimeType { get; set; }
        public byte[] Image { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
