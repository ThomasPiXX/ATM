namespace ATM;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        //create an instance of the AuthenticationForm  to get userid, nip, worth; 
        AuthenticationForm authenticationForm = new AuthenticationForm();
        authenticationForm.ShowDialog();

        if (authenticationForm.IsAuthenticated)
        {
            string userId = authenticationForm.userId;
            string pin = authenticationForm.pin;
            decimal worth = authenticationForm.worth;

            Application.Run(new Form1(authenticationForm, userId, pin, worth));
        }
        else
        {
            MessageBox.Show("authentication didnt work ");
            Application.Exit();
        }
        
    }    
}