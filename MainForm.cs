using Label = System.Windows.Forms.Label;
using Timer = System.Windows.Forms.Timer;

namespace DesktopClockApp
{
    public partial class MainForm : Form
    {
        private Label labelTime = new Label();
        Random random = new Random();

        public MainForm()
        {
            StartPosition = FormStartPosition.Manual;
            Location = GetLocation();
            InitializeComponent();
            InitializeTimer();


            // make the background transparent
            BackColor = Color.Gray;
            TransparencyKey = Color.Gray;

            // auto size to contents
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // remove border
            FormBorderStyle = FormBorderStyle.None;

        }

        private void InitializeTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 1000; // Update every second
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = GetTime();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //empty implementation
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Name = "labelTime";
            labelTime.TabIndex = 0;
            labelTime.ForeColor = Color.FromArgb(255, 250, 250, 250);
            labelTime.Font = new Font("Calibri", 24);
            labelTime.BackColor = Color.Gray;
            // 
            // MainForm
            // 
            Controls.Add(labelTime);
            Name = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }


        private string GetTime()
        {
            return DateTime.Now.ToString(labelTime.Text.Contains("AM") || labelTime.Text.Contains("PM") ? "hh:mm:ss tt" : "HH:mm:ss");
        }

        private Point GetLocation()
        {
            Screen screen = Screen.PrimaryScreen; 

            int x = screen.WorkingArea.Right - random.Next(150, 401);

            return new Point(x, 50); 
        }

    }
}