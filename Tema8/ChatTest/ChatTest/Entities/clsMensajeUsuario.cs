namespace ChatTest.Entities
{
    public class clsMensajeUsuario
    {
        public string user { get; set; }
        public string message { get; set; }

        public clsMensajeUsuario(string User, string Message)
        {
            this.user = User;
            this.message = Message;
        }

    }
}
