using System.Globalization;
using WindowsFormsApplication1;

namespace Client;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Task1Click(object sender, EventArgs e) // Обработчик кнопки
    {
        _answerLabel.Text = "Answer: ";
        _answerLabel.Text += Convert.ToString(
            Program.ThreeMax(
                Convert.ToDouble(_textBox1.Text),
                Convert.ToDouble(_textBox2.Text),
                Convert.ToDouble(_textBox3.Text))
        );
    }

    private void Task2Click(object sender, EventArgs e) // Обработчик кнопки
    {
        _answerLabel.Text = "Answer: ";
        _answerLabel.Text += Program.TwoSigns(
            Convert.ToDouble(_textBox1.Text),
            Convert.ToDouble(_textBox2.Text)
        );
    }

    private void Task3Click(object sender, EventArgs e) // Обработчик кнопки
    {
        _answerLabel.Text = "Answer: ";
        _answerLabel.Text += Program.AbsMax(
            Convert.ToDouble(_textBox1.Text),
            Convert.ToDouble(_textBox2.Text),
            Convert.ToDouble(_textBox3.Text)
        );
    }

    private void Task4Click(object sender, EventArgs e) // Обработчик кнопки
    {
        _answerLabel.Text = "Answer: ";
        _answerLabel.Text += Program.TwoDots(
            Convert.ToDouble(_textBox1.Text),
            Convert.ToDouble(_textBox2.Text),
            Convert.ToDouble(_textBox3.Text),
            Convert.ToDouble(_textBox4.Text),
            Convert.ToDouble(_textBox5.Text)
        );
    }

    private void Task5Click(object sender, EventArgs e) // Обработчик кнопки
    {
        _answerLabel.Text = "Answer: ";
        _answerLabel.Text += Program.AnotherBrickInTheWall(
            Convert.ToDouble(_textBox1.Text),
            Convert.ToDouble(_textBox2.Text),
            Convert.ToDouble(_textBox3.Text),
            Convert.ToDouble(_textBox4.Text),
            Convert.ToDouble(_textBox5.Text)
            );
    }
}