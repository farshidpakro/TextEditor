namespace TextEditor;

public partial class Form1 : Form
{
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private RichTextBox richTextBox1;

    public Form1()
    {
        InitializeComponent();
        this.Size = new System.Drawing.Size(1500, 700);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Name = "test";
        button1 = new Button();
        this.Controls.Add(button1);
        button1.Click += new EventHandler(button1_Click);
        button1.Text = "Save";
        button1.Location = new Point(70, 70);
        button1.Size = new Size(500, 100);
        button1.Location = new Point(40, 50);

        button2 = new Button();
        this.Controls.Add(button2);
        button2.Click += new EventHandler(button2_Click);
        button2.Text = "font";
        button2.Location = new Point(70, 70);
        button2.Size = new Size(500, 100);
        button2.Location = new Point(40, 160);

        button3 = new Button();
        this.Controls.Add(button3);
        button3.Click += new EventHandler(button3_Click);
        button3.Text = "TextColor";
        button3.Location = new Point(70, 70);
        button3.Size = new Size(500, 100);
        button3.Location = new Point(40, 270);

        button4 = new Button();
        this.Controls.Add(button4);
        button4.Click += new EventHandler(button4_Click);
        button4.Text = "BackgroundColor";
        button4.Location = new Point(70, 70);
        button4.Size = new Size(500, 100);
        button4.Location = new Point(40, 380);

        richTextBox1 = new RichTextBox();
        this.Controls.Add(richTextBox1);

        richTextBox1.Location = new Point(70, 70);
        richTextBox1.Size = new Size(800, 440);
        richTextBox1.Location = new Point(600, 50);


    }
    private void button1_Click(object sender, EventArgs e)
    {
        SaveFileDialog openFileDialog1 = new SaveFileDialog();
        openFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";
        openFileDialog1.AddExtension = true;
        if (openFileDialog1.ShowDialog() == DialogResult.OK &&
             openFileDialog1.FileName.Length > 0)
        {
            using (StreamWriter sw = new StreamWriter(openFileDialog1.OpenFile()))
            {
                sw.Write(richTextBox1.Text);
            }
        }


    }
    private void button2_Click(object sender, EventArgs e)
    {
        FontDialog fontDialog1 = new FontDialog();
        if (fontDialog1.ShowDialog() == DialogResult.OK)
        {
            if (richTextBox1.SelectedText != "")
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
            else if (richTextBox1.SelectedText == "")
            {
                richTextBox1.Font = fontDialog1.Font;

            }
        }
    }
    private void button3_Click(object sender, EventArgs e)
    {
        ColorDialog colorDialog1 = new ColorDialog();
        colorDialog1.AllowFullOpen = true;
        colorDialog1.AnyColor = true;
        colorDialog1.ShowHelp = true;
        // Sets the initial color select to the current text color.
        colorDialog1.Color = richTextBox1.ForeColor;
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {
            if (richTextBox1.SelectedText != "")
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
            else if (richTextBox1.SelectedText == "")
            {
                richTextBox1.ForeColor = colorDialog1.Color;

            }

            //richTextBox1.ForeColor = colorDialog1.Color;

        }

    }
    private void button4_Click(object sender, EventArgs e)
    {
        ColorDialog colorDialog1 = new ColorDialog();
        colorDialog1.AllowFullOpen = true;
        colorDialog1.AnyColor = true;
        colorDialog1.ShowHelp = true;
        // Sets the initial color select to the current text color.
        colorDialog1.Color = richTextBox1.ForeColor;
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {

            richTextBox1.BackColor = colorDialog1.Color;

        }
    }
}
