 using System;
using System.Drawing;
using System.Windows.Forms;

class StudentForm : Form
{
    Label nameLabel, genderLabel, courseLabel, skillsLabel;
    TextBox nameTextBox;

    GroupBox genderGroup;
    RadioButton maleRadio;
    RadioButton femaleRadio;

    ComboBox courseComboBox;

    CheckBox csharpCheckBox;
    CheckBox pythonCheckBox;

    Button submitButton;
    Label resultLabel;

    public StudentForm()
    {
        Text = "Student Registration Form";
        Size = new Size(550, 550);
        StartPosition = FormStartPosition.CenterScreen;

        // Name Label
        nameLabel = new Label();
        nameLabel.Text = "Name:";
        nameLabel.Location = new Point(50, 40);
        nameLabel.AutoSize = true;

        // Name TextBox
        nameTextBox = new TextBox();
        nameTextBox.Location = new Point(180, 35);
        nameTextBox.Width = 250;

        // Gender Label
        genderLabel = new Label();
        genderLabel.Text = "Gender:";
        genderLabel.Location = new Point(50, 100);
        genderLabel.AutoSize = true;

        // Gender GroupBox
        genderGroup = new GroupBox();
        genderGroup.Text = "Select Gender";
        genderGroup.Location = new Point(180, 75);
        genderGroup.Size = new Size(250, 55);

        // Male RadioButton
        maleRadio = new RadioButton();
        maleRadio.Text = "Male";
        maleRadio.Location = new Point(20, 20);
        maleRadio.AutoSize = true;

        // Female RadioButton
        femaleRadio = new RadioButton();
        femaleRadio.Text = "Female";
        femaleRadio.Location = new Point(120, 20);
        femaleRadio.AutoSize = true;

        genderGroup.Controls.Add(maleRadio);
        genderGroup.Controls.Add(femaleRadio);

        // Course Label
        courseLabel = new Label();
        courseLabel.Text = "Course:";
        courseLabel.Location = new Point(50, 165);
        courseLabel.AutoSize = true;

        // Course ComboBox
        courseComboBox = new ComboBox();
        courseComboBox.Location = new Point(180, 160);
        courseComboBox.Width = 250;
        courseComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        courseComboBox.Items.Add("B.Tech IT");
        courseComboBox.Items.Add("B.E CSE");
        courseComboBox.Items.Add("B.E ECE");
        courseComboBox.Items.Add("B.Sc Computer Science");

        // Skills Label
        skillsLabel = new Label();
        skillsLabel.Text = "Skills:";
        skillsLabel.Location = new Point(50, 220);
        skillsLabel.AutoSize = true;

        // C# CheckBox
        csharpCheckBox = new CheckBox();
        csharpCheckBox.Text = "C#";
        csharpCheckBox.Location = new Point(180, 215);
        csharpCheckBox.AutoSize = true;

        // Python CheckBox
        pythonCheckBox = new CheckBox();
        pythonCheckBox.Text = "Python";
        pythonCheckBox.Location = new Point(270, 215);
        pythonCheckBox.AutoSize = true;

        // Submit Button
        submitButton = new Button();
        submitButton.Text = "Submit";
        submitButton.Location = new Point(180, 270);
        submitButton.Width = 100;
        submitButton.Height = 35;

        submitButton.Click += SubmitButton_Click;

        // Result Label
        resultLabel = new Label();
        resultLabel.Location = new Point(50, 330);
        resultLabel.AutoSize = true;

        // Add controls to form
        Controls.Add(nameLabel);
        Controls.Add(nameTextBox);
        Controls.Add(genderLabel);
        Controls.Add(genderGroup);
        Controls.Add(courseLabel);
        Controls.Add(courseComboBox);
        Controls.Add(skillsLabel);
        Controls.Add(csharpCheckBox);
        Controls.Add(pythonCheckBox);
        Controls.Add(submitButton);
        Controls.Add(resultLabel);
    }

    private void SubmitButton_Click(object sender, EventArgs e)
    {
        string name = nameTextBox.Text;

        string gender;

        if (maleRadio.Checked)
            gender = "Male";
        else if (femaleRadio.Checked)
            gender = "Female";
        else
            gender = "Not Selected";

        string course = courseComboBox.Text;

        string skills = "";

        if (csharpCheckBox.Checked)
            skills += "C# ";

        if (pythonCheckBox.Checked)
            skills += "Python";

        if (skills == "")
            skills = "None";

        resultLabel.Text =
            "--- Student Details ---\n" +
            "Name   : " + name + "\n" +
            "Gender : " + gender + "\n" +
            "Course : " + course + "\n" +
            "Skills : " + skills;
    }

    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new StudentForm());
    }
}