using System.Drawing;
using System.Windows.Forms;

namespace ATM
{   

    public class GetCashForm : Form
    {
        private Label displayLabel;
        private string currentAmount;
        private string previousAmount;

        public GetCashForm()
        {
            displayLabel = new Label();
            displayLabel.Font = new Font("Arial", 24, FontStyle.Bold);
            displayLabel.Width = 300;
            displayLabel.Height = 70;
            displayLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(displayLabel);

            //form size 
            Width = 400;
            Height = 300;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Get Cash";
            FormBorderStyle = FormBorderStyle.FixedDialog;


            // button 20,50,100,cancel
            string[] cashButton = {"20$", "50$", "100$", "Cancel"};
            foreach ( string amount in cashButton )
            {
                Button moneyButton = new Button();
                moneyButton.Text = amount;
                moneyButton.Width = 70;
                moneyButton.Height = 70;
                moneyButton += MoneyButtonClick;
                this.Controls.Add(moneyButton); 
            }
        }

        private void MoneyButtonClick(object? sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            switch(buttonText)
            {
                case "20$":
                    Handle20(buttonText);
                    break;
                case "50$":
                    Handle50(buttonText);
                    break;
                case "100$":
                    Handle100(buttonText);
                     break;
                case "Cancel":
                    handleCancel(buttonText);
                     break;
                    
            }

            }
        private void Handle20(string buttonText)
        {
            previousAmount = currentAmount;
            currentAmount = buttonText;
            TotalCash();

            
        }  

        private void Handle50(string buttonText)
        {
            previousAmount = currentAmount;
            currentAmount = buttonText;
            TotalCash();
        }

        private void Handle100(string buttonText)
        {
            previousAmount = currentAmount;
            currentAmount = buttonText;
            TotalCash();
        }

        private void HandleCancel(string buttonText)
        {

        }

        private void TotalCash()
        {
            
        }
    }


    public partial class Form1 : Form
    {
        private string currentNumber;
        private string previousNumber;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label displayLabel;

        public Form1()
        {
            InitializeComponent();
            this.Text = "ATM";
            //create a flow layout pannel
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            this.Controls.Add(flowLayoutPanel1);

            //create a display
            displayLabel = new Label();
            displayLabel.Font = new Font("Arial", 24, FontStyle.Bold);
            displayLabel.Width = 300;
            displayLabel.Height = 70;
            displayLabel.TextAlign = ContentAlignment.MiddleCenter;
            displayLabel.Margin = new Padding(5, 10, 5, 5);
            flowLayoutPanel1.Controls.Add(displayLabel);

            //creating table row and columns 
            TableLayoutPanel tableLayout = new TableLayoutPanel();
            tableLayout.Height = 300;
            tableLayout.Width = 300;
            tableLayout.AutoSize = false;
            tableLayout.ColumnCount = 4;
            tableLayout.RowCount = 4;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayout.Dock = DockStyle.Fill;
            flowLayoutPanel1.Controls.Add(tableLayout);

            //KeyPad number sorting
            string[] keyPad = { "1", "2", "3", "Clear", "4", "5", "6", "Cancel", "7", "8", "9", "Ok", " ", "0", " " };
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int index = row * 4 + col;
                    Button buttonKey = new Button();
                    buttonKey.Text = keyPad[index];
                    buttonKey.Width = 50;
                    buttonKey.Height = 50;
                    buttonKey.AutoSize = false;
                    buttonKey.Margin = new Padding(0);
                    buttonKey.Padding = new Padding(0);
                    buttonKey.Click += ButtonClick;
                    flowLayoutPanel1.Controls.Add(buttonKey);
                }
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            switch (buttonText)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    HandleDigit(buttonText);
                    break;
                case "Clear":
                    HandleClear(buttonText);
                    break;
                case "Cancel":
                    HandleCancel(buttonText);
                    break;
                case "Ok":
                    HandleOk(buttonText);
                    break;
                case "Select":
                    HandleOk(buttonText);
                    break;
                case "Get cash":
                    HandleGetCash(buttonText);
                    break;
                
            
                
            }
        }

        private void HandleDigit(string buttonText)
        {
            currentNumber += buttonText;
            UpdateDisplay();
        }

        private void HandleClear(string ButtonText)
        {
            currentNumber = "";
            previousNumber = "";
            UpdateDisplay();
        }

        private void HandleCancel(string ButtonText)
        {
            MainDisplay();
        }

        private void HandleOk(string ButtonText)
        {
            ConfirmNumber();
        }

        private void HandleGetCash(string Buttontext)
        {
            GetCash();
        }

    }
}
