namespace Reto;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) =>
            MessageBox.Show("Ocurrió un error: " + e.Exception.Message, "Agenda",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
