namespace ATM;

public partial class Form1 : Form
    {
    private FlowLayoutPanel FlowLayoutPanel;
    private Label? displayLabel;
    public Form1()
    {
        InitializeComponent();
        //create a flow layout pannel
        FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel();
        flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        flowLayoutPanel1.Dock = DockStyle.Fill;

        //create a display
        displayLabel = new Label();
        displayLabel.Font = new Font("Arial", 24, FontStyle.Bold);
        displayLabel.Width = 300;
        displayLabel.Height = 70;
        displayLabel.TextAlign = ContentAlignment.MiddleCenter;
        displayLabel.Margin = new Padding(5, 10, 5, 5);
        flowLayoutPanel1.Controls.Add(displayLabel);
    }   

}
