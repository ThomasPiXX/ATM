using System.Drawing;
using System.Windows.Forms;

namespace ATM
{
    public class MainForm : Form
    {
        private Label displayLabel;
        private string currentAmount ="0";
        private Button getcashButton;
        private Panel keypadPannel;
        private TableLayoutPanel cashAmountPanel;

        public MainForm()
        {
            //Set up the form

            Width = 400;
            Height = 300;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ATM"

            //Create the Get Cash button
            getcashButton = new Button();
            getcashButton.Text = "Get Cash";
            getcashButton.Width = 100;
            getcashButton.Height = 50;
            getcashButton.Location = new Point(20, 20);
            getcashButton.Click += GetCashButtonClick;
            this.Controls.Add(getcashButton);

            //Create the display label
            displayLabel = new Label();
            displayLabel.Font = new Font("Arial", 24, FontStyle.Bold);
            displayLabel.Width = 300;
            displayLabel.Height = 70;
            displayLabel.TextAlign = ContentAlignment.MiddleCenter;
            displayLabel.Location = new Point(50, 100);
            this.Controls.Add(displayLabel);

            //Create the keypad panel
            keypadPannel = new Panel();
            keypadPannel.Width = 250;
            keypadPannel.Height = 200;
            keypadPannel.Location = new Point(70, 150);
            keypadPannel.Visible = false;
            this.Controls.Add(keypadPannel);

            //Create the cash amount Pannel

            
             
        }
    }
}