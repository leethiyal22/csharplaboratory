using System;
using System.Drawing;
using System.Windows.Forms;

class CalculatorForm : Form
{
    Label titleLabel;
    Label firstLabel;
    Label secondLabel;
    Label resultLabel;

    TextBox firstTextBox;
    TextBox secondTextBox;

    Button addButton;
    Button subtractButton;
    Button multiplyButton;
    Button divideButton;
    Button clearButton;

    Panel resultPanel;

    public CalculatorForm()
    {
        Text = "Simple Calculator";
        Size = new Size(550, 500);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.LightSteelBlue;

        titleLabel = new Label();
        titleLabel.Text = "SIMPLE CALCULATOR";
        titleLabel.Location = new Point(160, 30);
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Arial", 16, FontStyle.Bold);
        titleLabel.BackColor = Color.DarkBlue;
        titleLabel.ForeColor = Color.White;
        titleLabel.Padding = new Padding(10);

        firstLabel = new Label();
        firstLabel.Text = "First Number:";
        firstLabel.Location = new Point(70, 110);
        firstLabel.AutoSize = true;

        firstTextBox = new TextBox();
        firstTextBox.Location = new Point(200, 105);
        firstTextBox.Width = 220;
        firstTextBox.BackColor = Color.White;

        secondLabel = new Label();
        secondLabel.Text = "Second Number:";
        secondLabel.Location = new Point(70, 160);
        secondLabel.AutoSize = true;

        secondTextBox = new TextBox();
        secondTextBox.Location = new Point(200, 155);
        secondTextBox.Width = 220;
        secondTextBox.BackColor = Color.White;

        addButton = new Button();
        addButton.Text = "+ Add";
        addButton.Location = new Point(70, 210);
        addButton.Size = new Size(90, 40);
        addButton.BackColor = Color.LightGreen;
        addButton.Click += AddButton_Click;

        subtractButton = new Button();
        subtractButton.Text = "- Subtract";
        subtractButton.Location = new Point(170, 210);
        subtractButton.Size = new Size(90, 40);
        subtractButton.BackColor = Color.LightYellow;
        subtractButton.Click += SubtractButton_Click;

        multiplyButton = new Button();
        multiplyButton.Text = "× Multiply";
        multiplyButton.Location = new Point(270, 210);
        multiplyButton.Size = new Size(90, 40);
        multiplyButton.BackColor = Color.LightPink;
        multiplyButton.Click += MultiplyButton_Click;

        divideButton = new Button();
        divideButton.Text = "÷ Divide";
        divideButton.Location = new Point(370, 210);
        divideButton.Size = new Size(90, 40);
        divideButton.BackColor = Color.LightCyan;
        divideButton.Click += DivideButton_Click;

        resultPanel = new Panel();
        resultPanel.Location = new Point(100, 285);
        resultPanel.Size = new Size(340, 70);
        resultPanel.BackColor = Color.White;
        resultPanel.BorderStyle = BorderStyle.FixedSingle;

        resultLabel = new Label();
        resultLabel.Text = "Result: ";
        resultLabel.Location = new Point(20, 20);
        resultLabel.AutoSize = true;
        resultLabel.Font = new Font("Arial", 12, FontStyle.Bold);

        resultPanel.Controls.Add(resultLabel);

        clearButton = new Button();
        clearButton.Text = "Clear";
        clearButton.Location = new Point(220, 380);
        clearButton.Size = new Size(100, 40);
        clearButton.BackColor = Color.LightGray;
        clearButton.Click += ClearButton_Click;

        Controls.Add(titleLabel);
        Controls.Add(firstLabel);
        Controls.Add(firstTextBox);
        Controls.Add(secondLabel);
        Controls.Add(secondTextBox);
        Controls.Add(addButton);
        Controls.Add(subtractButton);
        Controls.Add(multiplyButton);
        Controls.Add(divideButton);
        Controls.Add(resultPanel);
        Controls.Add(clearButton);
    }

    private bool GetNumbers(out double num1, out double num2)
    {
        num1 = 0;
        num2 = 0;

        if (double.TryParse(firstTextBox.Text, out num1) &&
            double.TryParse(secondTextBox.Text, out num2))
        {
            return true;
        }

        resultLabel.Text = "Please enter valid numbers.";
        resultPanel.BackColor = Color.LightCoral;

        return false;
    }

    private void AddButton_Click(object? sender, EventArgs e)
    {
        if (GetNumbers(out double a, out double b))
        {
            resultLabel.Text = "Result: " + (a + b);
            resultPanel.BackColor = Color.LightGreen;
        }
    }

    private void SubtractButton_Click(object? sender, EventArgs e)
    {
        if (GetNumbers(out double a, out double b))
        {
            resultLabel.Text = "Result: " + (a - b);
            resultPanel.BackColor = Color.LightYellow;
        }
    }

    private void MultiplyButton_Click(object? sender, EventArgs e)
    {
        if (GetNumbers(out double a, out double b))
        {
            resultLabel.Text = "Result: " + (a * b);
            resultPanel.BackColor = Color.LightPink;
        }
    }

    private void DivideButton_Click(object? sender, EventArgs e)
    {
        if (GetNumbers(out double a, out double b))
        {
            if (b == 0)
            {
                resultLabel.Text = "Cannot divide by zero.";
                resultPanel.BackColor = Color.LightCoral;
                return;
            }

            resultLabel.Text = "Result: " + (a / b);
            resultPanel.BackColor = Color.LightCyan;
        }
    }

    private void ClearButton_Click(object? sender, EventArgs e)
    {
        firstTextBox.Clear();
        secondTextBox.Clear();

        resultLabel.Text = "Result: ";
        resultPanel.BackColor = Color.White;
    }

    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new CalculatorForm());
    }
}