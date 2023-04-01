using System.Drawing;
using System.Windows.Forms;

namespace ATM
{
    public class MainForm : Form
    {
        private Label displayLabel;
        private string currentAmount = "\0";
        private Button getcashButton;
        private Panel keypadPanel;
        private TableLayoutPanel cashAmountPanel;

        public MainForm()
        {
            //Set up the form

            Width = 400;
            Height = 300;
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
            displayLabel.Location = new Point(50, 100);
            this.Controls.Add(displayLabel);

            //Create the keypad panel
            keypadPanel = new Panel();
            keypadPanel.Width = 250;
            keypadPanel.Height = 200;
            keypadPanel.Location = new Point(70, 150);
            keypadPanel.Visible = false;
            this.Controls.Add(keypadPannel);

            //Create the cash amount Pannel
            cashAmountPanel = new TableLayoutPanel();
            cashAmountPanel.Width = 250;
            cashAmountPanel.Height = 200;
            cashAmountPanel.Location = new Point(70, 150);
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

            string[] keypadButtonLabels = { "1", "2", "3", "C", "4", "5", "6", "Cancel", "7", "8", "9", "OK", "", "0", ""};
            for (int i = 0; i < keypadButtonLabels.Length; i++)
            {
                Button keypadButton = new Button();
                keypadButton.Text = keypadButtonLabels[i];
                keypadButton.Width = 50;
                keypadButton.Height = 50;
                keypadButton.Click += KeypadButtonClick;
                keypadPanel.Controls.Add(keypadButton);
                
            }
        }
        private void GetCashButtonClick(object sender, EventArgs e)
        {
            //Hide the Get Cash button
            getcashButton.Visible = false;

            //Show the cash amount panel
            cashAmountPanel.Visible = true;

            // add the cash amount buttons
            string[] cashAmountButtonLabels = {"$20", "$50", "$100", "Custom" };
            for (int i = 0; i < cashAmountButtonLabels.Length; i++);
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
                    HandleCustom();
                    break;
            }
        }

        private void Handle20()
        {   
            int amount = 20;
            int result = int.Parse(currentAmount) + amount;
            currentAmount = result.ToString();
            UpdateDisplay();
        }

        private void Handle50()
        {
            int amount = 50;
            int result = int.Parse(currentAmount) + amount;
            currentAmount = result.ToString();
            UpdateDisplay();
        }

        private void Handle100()
        {
            int amount = 100;
            int result = int.Parse(currentAmount) + amount;
            currentAmount = result.ToString();
            UpdateDisplay();
        }

        private void HandleCustom()
        {
            keypadPanel.Visible = true;
            currentAmount = 
        }
    

    }


}