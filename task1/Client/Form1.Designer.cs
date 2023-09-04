using System.Windows.Forms.VisualStyles;

namespace Client;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private Label _answerLabel = new Label();
    private Label _descriptionLabel = new Label();
    
    private TextBox _textBox1 = new TextBox();
    private TextBox _textBox2 = new TextBox();
    private TextBox _textBox3 = new TextBox();
    private TextBox _textBox4 = new TextBox(); 
    private TextBox _textBox5 = new TextBox();

    private EventHandler _currentEventHandler = null;
    private Button _answerButton = new Button();

    private Button _task1 = new Button();
    private EventHandler _task1Event = null;
    
    private Button _task2 = new Button();
    private EventHandler _task2Event = null;
    
    private Button _task3 = new Button();
    private EventHandler _task3Event = null;
    
    private Button _task4 = new Button();
    private EventHandler _task4Event = null;
    
    private Button _task5 = new Button();
    private EventHandler _task5Event = null;
    
    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private T CreateControl<T>(T control, int x, int y, string text) where T : Control
    {
        this.Controls.Add(control);
        control.Location = new Point(x, y);
        control.Text = text;
        control.AutoSize = true;
        return control;
    }

    private void CreateControl(Button button, int x, int y, string text, EventHandler handler)
    {
        CreateControl<Button>(button, x, y, text);
        button.Click += handler;
    }
    
    
    private void ShowTask1(object sender, EventArgs e)
    {   
        _textBox3.Show();
        _textBox4.Hide();
        _textBox5.Hide();

        _descriptionLabel.Text = "Max";
        
        _answerButton.Click -= _currentEventHandler;
        _answerButton.Click += _task1Event;
        _currentEventHandler = _task1Event;
    }
    
    private void ShowTask2(object sender, EventArgs e)
    {
        _textBox3.Hide();
        _textBox4.Hide();
        _textBox5.Hide();
        
        _descriptionLabel.Text = "Diff signs";

        _answerButton.Click -= _currentEventHandler;
        _answerButton.Click += _task2Event;
        _currentEventHandler = _task2Event;
    }
    
    private void ShowTask3(object sender, EventArgs e)
    {
        _textBox3.Show();
        _textBox4.Hide();
        _textBox5.Hide();
        
        _descriptionLabel.Text = "Abs Max";

        _answerButton.Click -= _currentEventHandler;
        _answerButton.Click += _task3Event;
        _currentEventHandler = _task3Event;
    }
    
    private void ShowTask4(object sender, EventArgs e)
    {
        _textBox3.Show();
        _textBox4.Show();
        _textBox5.Show();
        
        _descriptionLabel.Text = "Is two dots in a circle";

        _answerButton.Click -= _currentEventHandler;
        _answerButton.Click += _task4Event;
        _currentEventHandler = _task4Event;
    }
    
    private void ShowTask5(object sender, EventArgs e)
    {
        _textBox3.Show();
        _textBox4.Show();
        _textBox5.Show();
        
        _descriptionLabel.Text = "Is fit";
        
        _answerButton.Click -= _currentEventHandler;
        _answerButton.Click += _task5Event;
        _currentEventHandler = _task5Event;
    }

    private void CreateIO()
    {
        CreateControl<Label>(_answerLabel, 200, 10, "Answer");
        CreateControl<Label>(_descriptionLabel, 200, 200, "Max");
        
        CreateControl<TextBox>(_textBox1, 0, 50, "Input 1");
        CreateControl<TextBox>(_textBox2, 100, 50, "Input 2");
        CreateControl<TextBox>(_textBox3, 200, 50, "Input 3");
        CreateControl<TextBox>(_textBox4, 300, 50, "Input 4").Hide();
        CreateControl<TextBox>(_textBox5, 400, 50, "Input 5").Hide();
    }

    private void CreateDock()
    {
        CreateControl(_task1, 0, 300, "Task 1", ShowTask1);
        _task1Event = new EventHandler(Task1Click);
        
        CreateControl(_task2, 100, 300, "Task 2", ShowTask2);
        _task2Event = new EventHandler(Task2Click);
        
        CreateControl(_task3, 200, 300, "Task 3", ShowTask3);
        _task3Event = new EventHandler(Task3Click);
        
        CreateControl(_task4, 300, 300, "Task 4", ShowTask4);
        _task4Event = new EventHandler(Task4Click);
        
        CreateControl(_task5, 400, 300, "Task 5", ShowTask5);
        _task5Event = new EventHandler(Task5Click);
    }
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Form1";

        CreateIO();
        
        CreateDock();

        CreateControl<Button>(_answerButton, 200, 100, "Click Me!");
        _answerButton.Click += _task1Event;
        _currentEventHandler = _task1Event;
    }
}