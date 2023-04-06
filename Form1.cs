using System.Drawing;
using System.Windows.Forms;

namespace ATM
{
    public partial class Form1: Form
    {   
        private Label displayLabel;
        private string currentAmount = "0";
        private Button getcashButton;
        private TableLayoutPanel keypadPanel;
        private TableLayoutPanel cashAmountPanel;
        private string customAmount = "";
        

        public Form1()
        {
            InitializeComponent();

            //Set up the form
            Width = 500;
            Height = 400;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ATM";

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
            displayLabel.Location = new Point(50, 30);
            this.Controls.Add(displayLabel);

            //Create the keypad panel
            keypadPanel = new TableLayoutPanel();
            keypadPanel.Width = 200;
            keypadPanel.Height = 250;
            keypadPanel.Location = new Point(125, 100);
            keypadPanel.Visible = false;
            keypadPanel.RowCount = 4;
            keypadPanel.ColumnCount = 4;
            keypadPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            keypadPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            keypadPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            keypadPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            keypadPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            keypadPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            keypadPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            keypadPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            keypadPanel.Dock = DockStyle.None;
            keypadPanel.Anchor = AnchorStyles.None;
            this.Controls.Add(keypadPanel);

            //Create the cash amount Pannel
            cashAmountPanel = new TableLayoutPanel();
            cashAmountPanel.Width = 250;
            cashAmountPanel.Height = 200;
            cashAmountPanel.Location = new Point(80, 170);
            cashAmountPanel.Visible = false;
            cashAmountPanel.ColumnCount = 2;
            cashAmountPanel.RowCount = 4;
            cashAmountPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            cashAmountPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            cashAmountPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            cashAmountPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            cashAmountPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            cashAmountPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            this.Controls.Add(cashAmountPanel);

            //Create the keypad buttons 

            string[] keypadButtonLabels = { "1", "2", "3", "C", "4", "5", "6", "Cancel", "7", "8", "9", "OK", "", "0", "",""};
            for (int row = 0; row < 4; row++)
            {   
                for (int col = 0; col < 4 ; col++ )
                {   
                    int index = row * 4 + col;    
                    Button keypadButton = new Button();
                    keypadButton.Text = keypadButtonLabels[index];
                    keypadButton.Width = 50;
                    keypadButton.Height = 50;
                    keypadButton.Click += KeypadButtonClick;
                    keypadButton.Dock = DockStyle.Fill;
                    keypadPanel.Controls.Add(keypadButton, col, row);
                    
                }
            }  
        }
        private void KeypadButtonClick(object sender, EventArgs e)
        {
            Button keypadNumber = (Button)sender;
            string number = keypadNumber.Text;
        

            switch(number)
            {
                case"1":
                case"2":
                case"3":
                case"4":
                case"5":
                case"6":
                case"7":
                case"8":
                case"9":
                    HandleKeypadDigit(number);
                    break;
                case"C":
                    HandleKeypadClear(number);
                    break;
                case"Cancel":
                    HandleKeypadCancel(number);
                    break;

            } 
        }
        private void HandleKeypadDigit(string number)
        {
            currentAmount += number;
            
            UpdateDisplay();
        }
        private void HandleKeypadClear(string number)
        {
            currentAmount = "0";

            UpdateDisplay();
        }
        private void HandleKeypadCancel(string number)
        {   
            currentAmount = "0";
            UpdateDisplay();
            keypadPanel.Visible = false;
            displayLabel.Visible = false;
            getcashButton.Visible = true;

        }
        
        private void UpdateDisplay()
        {
            displayLabel.Text = "$" + currentAmount;
        }
        public void GetCashButtonClick(object sender, EventArgs e)
        {

            // clear the panel berofre populatin it again 
            cashAmountPanel.Controls.Clear(); 

            //Hide the Get Cash button
            getcashButton.Visible = false;
            
            displayLabel.Visible = true;
            //Show the cash amount panel
            cashAmountPanel.Visible = true;

            
            // add the cash amount buttons
            string[] cashAmountButtonLabels = {"$20", "$50", "$100", "Custom" };
            for (int i = 0; i < cashAmountButtonLabels.Length; i++)
            {
                Button cashAmountButton = new Button();
                cashAmountButton.Text = cashAmountButtonLabels[i];
                cashAmountButton.Width = 100;
                cashAmountButton.Height = 100;
                cashAmountButton.Click += CashAmountButtonClick;
                cashAmountPanel.Controls.Add(cashAmountButton);
            }

        }
        private void CashAmountButtonClick(object? sender, EventArgs e)
        {
            Button amountButton = (Button) sender;
            string buttonLabels = amountButton.Text;

            switch(buttonLabels)
            {
                case"$20":
                    Handle20();
                    break;
                case"$50":
                    Handle50();
                    break;
                case"$100":
                    Handle100();
                    break;
                case"Custom":
                    currentAmount = "";
                    HandleCustom();
                    break;
            }
        }

        private void Handle20()
        { 
            
            int amount = 20 ;
            int result = int.Parse(currentAmount) + amount;
            currentAmount = result.ToString();
            UpdateDisplay();


        }

        public void Handle50()
        {   
            
            int amount = 50;
            int result = int.Parse(currentAmount) + amount;
            currentAmount = result.ToString();
            UpdateDisplay();
        }

        public void Handle100()
        {
            
            int amount = 100;
            int result = int.Parse(currentAmount) + amount;
            currentAmount = result.ToString();
            UpdateDisplay();
        }

        public void HandleCustom()
        {   
            customAmount = "0";
            keypadPanel.Visible = true;
            cashAmountPanel.Visible = false;

            
            

            UpdateDisplay();
        }
        

    }


}