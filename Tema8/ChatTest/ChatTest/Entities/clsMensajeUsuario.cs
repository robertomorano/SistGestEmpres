namespace ChatTest.Entities
{
    public class clsMensajeUsuario
    {
        public string user { get; set; }
        public string message { get; set; }

        clsMensajeUsuario(string user, string message)
        {
            user = user;
            message = message;
        }
    }
}
