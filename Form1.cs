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
        
        Console.WriteLine("hello");
        //create a display
        displayLabel = new Label();
        displayLabel.Font = new Font("Arial", 24, FontStyle.Bold);
        displayLabel.Width = 300;
        displayLabel.Height = 70;
        displayLabel.TextAlign = ContentAlignment.MiddleCenter;
        displayLabel.Margin = new Padding(5, 10, 5, 5);
        flowLayoutPanel1.Controls.Add(displayLabel);
        Console.WriteLine("hello2");
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
                flowLayoutPanel1.Controls.Add(buttonKey);
            }
                
        }
    
         this.Controls.Add(flowLayoutPanel1);
    }
    

        

}