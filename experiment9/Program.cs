using System;
using System.Drawing;
using System.Windows.Forms;

// Custom Dialog Box
class StudentDialog : Form
{
    Label nameLabel;
    Label courseLabel;
    TextBox nameTextBox;
    ComboBox courseComboBox;
    Button okButton;
    Button cancelButton;

    public StudentDialog()
    {
        Text = "Student Details";
        Size = new Size(400, 300);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        nameLabel = new Label();
        nameLabel.Text = "Student Name:";
        nameLabel.Location = new Point(40, 50);
        nameLabel.AutoSize = true;

        nameTextBox = new TextBox();
        nameTextBox.Location = new Point(160, 45);
        nameTextBox.Width = 180;

        courseLabel = new Label();
        courseLabel.Text = "Course:";
        courseLabel.Location = new Point(40, 100);
        courseLabel.AutoSize = true;

        courseComboBox = new ComboBox();
        courseComboBox.Location = new Point(160, 95);
        courseComboBox.Width = 180;
        courseComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        courseComboBox.Items.Add("B.Tech IT");
        courseComboBox.Items.Add("B.E CSE");
        courseComboBox.Items.Add("B.E ECE");
        courseComboBox.Items.Add("B.Sc Computer Science");

        okButton = new Button();
        okButton.Text = "OK";
        okButton.Location = new Point(160, 160);
        okButton.Size = new Size(80, 35);
        okButton.DialogResult = DialogResult.OK;

        cancelButton = new Button();
        cancelButton.Text = "Cancel";
        cancelButton.Location = new Point(250, 160);
        cancelButton.Size = new Size(80, 35);
        cancelButton.DialogResult = DialogResult.Cancel;

        Controls.Add(nameLabel);
        Controls.Add(nameTextBox);
        Controls.Add(courseLabel);
        Controls.Add(courseComboBox);
        Controls.Add(okButton);
        Controls.Add(cancelButton);

        AcceptButton = okButton;
        CancelButton = cancelButton;
    }

    public string StudentName
    {
        get { return nameTextBox.Text; }
    }

    public string Course
    {
        get { return courseComboBox.Text; }
    }
}


// Student Child Form
class StudentForm : Form
{
    Label titleLabel;
    Label detailsLabel;

    public StudentForm(string name, string course)
    {
        Text = "Student Information";
        BackColor = Color.White;
        Size = new Size(500, 350);

        titleLabel = new Label();
        titleLabel.Text = "STUDENT INFORMATION";
        titleLabel.Location = new Point(130, 50);
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Arial", 16, FontStyle.Bold);

        detailsLabel = new Label();
        detailsLabel.Text =
            "Student Name : " + name + "\n\n" +
            "Course       : " + course;

        detailsLabel.Location = new Point(100, 120);
        detailsLabel.AutoSize = true;
        detailsLabel.Font = new Font("Arial", 12);

        Controls.Add(titleLabel);
        Controls.Add(detailsLabel);
    }
}


// About Child Form
class AboutForm : Form
{
    Label aboutLabel;

    public AboutForm()
    {
        Text = "About";
        Size = new Size(450, 300);
        BackColor = Color.White;

        aboutLabel = new Label();

        aboutLabel.Text =
            "C# and .NET Laboratory\n\n" +
            "Experiment 9\n\n" +
            "Custom Dialog Box and MDI Application\n\n" +
            "Developed using Windows Forms";

        aboutLabel.Location = new Point(80, 60);
        aboutLabel.AutoSize = true;
        aboutLabel.Font = new Font("Arial", 12, FontStyle.Bold);

        Controls.Add(aboutLabel);
    }
}


// MDI Parent Form
class MainForm : Form
{
    MenuStrip menuStrip;

    ToolStripMenuItem fileMenu;
    ToolStripMenuItem studentMenu;
    ToolStripMenuItem aboutMenu;
    ToolStripMenuItem exitMenu;

    ToolStripMenuItem windowMenu;
    ToolStripMenuItem cascadeMenu;
    ToolStripMenuItem tileHorizontalMenu;
    ToolStripMenuItem tileVerticalMenu;

    public MainForm()
    {
        Text = "C# MDI Application";
        Size = new Size(900, 600);
        IsMdiContainer = true;
        BackColor = Color.LightSteelBlue;

        // Create MenuStrip
        menuStrip = new MenuStrip();

        // File Menu
        fileMenu = new ToolStripMenuItem("File");

        studentMenu = new ToolStripMenuItem("Student Details");
        aboutMenu = new ToolStripMenuItem("About");
        exitMenu = new ToolStripMenuItem("Exit");

        fileMenu.DropDownItems.Add(studentMenu);
        fileMenu.DropDownItems.Add(aboutMenu);
        fileMenu.DropDownItems.Add(new ToolStripSeparator());
        fileMenu.DropDownItems.Add(exitMenu);

        // Window Menu
        windowMenu = new ToolStripMenuItem("Window");

        cascadeMenu = new ToolStripMenuItem("Cascade");
        tileHorizontalMenu = new ToolStripMenuItem("Tile Horizontal");
        tileVerticalMenu = new ToolStripMenuItem("Tile Vertical");

        windowMenu.DropDownItems.Add(cascadeMenu);
        windowMenu.DropDownItems.Add(tileHorizontalMenu);
        windowMenu.DropDownItems.Add(tileVerticalMenu);

        // Add menus to MenuStrip
        menuStrip.Items.Add(fileMenu);
        menuStrip.Items.Add(windowMenu);

        Controls.Add(menuStrip);
        MainMenuStrip = menuStrip;

        // Menu Events
        studentMenu.Click += StudentMenu_Click;
        aboutMenu.Click += AboutMenu_Click;
        exitMenu.Click += ExitMenu_Click;

        cascadeMenu.Click += CascadeMenu_Click;
        tileHorizontalMenu.Click += TileHorizontalMenu_Click;
        tileVerticalMenu.Click += TileVerticalMenu_Click;
    }

    private void StudentMenu_Click(object? sender, EventArgs e)
    {
        StudentDialog dialog = new StudentDialog();

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            if (dialog.StudentName == "" || dialog.Course == "")
            {
                MessageBox.Show(
                    "Please enter student name and select course.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            StudentForm studentForm =
                new StudentForm(dialog.StudentName, dialog.Course);

            studentForm.MdiParent = this;
            studentForm.Show();
        }
    }

    private void AboutMenu_Click(object? sender, EventArgs e)
    {
        AboutForm aboutForm = new AboutForm();

        aboutForm.MdiParent = this;
        aboutForm.Show();
    }

    private void ExitMenu_Click(object? sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show(
            "Do you want to exit the application?",
            "Exit",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (result == DialogResult.Yes)
        {
            Application.Exit();
        }
    }

    private void CascadeMenu_Click(object? sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.Cascade);
    }

    private void TileHorizontalMenu_Click(object? sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void TileVerticalMenu_Click(object? sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.TileVertical);
    }
}


// Main Program
class Program
{
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(new MainForm());
    }
}