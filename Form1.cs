using System.Drawing;
using System.Windows.Forms;


namespace ATM;

public partial class Form1 : Form
{
    private FlowLayoutPanel flowLayoutPanel1;
    private Label? displayLabel;
    public Form1()
    {
        InitializeComponent();
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
        string[] keyPad = {"1", "2", "3","Clear", "4", "5", "6", "cancel", "7", "8", "9", "ok", " ", "0", " "};
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
    
        private void ButtonClick(object? sender, EventArgs e)
        {
            Button button = (Button)sender;
        }
    }
    

        

}