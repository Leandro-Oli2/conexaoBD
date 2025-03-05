using System;
using System.Drawing;
using System.Windows.Forms;

namespace Exemplo2_Console_Forms
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args){
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Calculadora());
        }
    }

    public class Calculadora : Form
    {
        private Label label1, label2;
        private TextBox textBox1, textBox2;
        private Button button1;

        public Calculadora()
        {
            this.Text = "Calculadora";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGray;
            this.Font = new Font("Arial", 10, FontStyle.Bold);

            label1 = new Label();
            label1.Text = "Número 1:";
            label1.Location = new Point(30, 30);
            label1.Size = new Size(100, 25);

            textBox1 = new TextBox();
            textBox1.Location = new Point(150, 30);
            textBox1.Size = new Size(180, 25);

            label2 = new Label();
            label2.Text = "Número 2:";
            label2.Location = new Point(30, 70);
            label2.Size = new Size(100, 25);

            textBox2 = new TextBox();
            textBox2.Location = new Point(150, 70);
            textBox2.Size = new Size(180, 25);

            button1 = new Button();
            button1.Text = "Calcular";
            button1.Location = new Point(120, 120);
            button1.Size = new Size(150, 40);
            button1.BackColor = Color.Green;
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Click += new EventHandler(Button1_Click);

            this.Controls.Add(label1);
            this.Controls.Add(textBox1);
            this.Controls.Add(label2);
            this.Controls.Add(textBox2);
            this.Controls.Add(button1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = Convert.ToInt32(textBox1.Text);
                int num2 = Convert.ToInt32(textBox2.Text);
                string resultado = $"Soma: {num1 + num2}\n" +
                                  $"Subtração: {num1 - num2}\n" +
                                  $"Multiplicação: {num1 * num2}\n" +
                                  $"Divisão: {(num2 != 0 ? (num1 / (double)num2).ToString("F2") : "Erro: divisão por zero")}";
                ResultadoForm resultadoForm = new ResultadoForm(resultado);
                resultadoForm.ShowDialog();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, insira valores numéricos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public class ResultadoForm : Form{
        public ResultadoForm(string resultado)
        {
            this.Text = "Resultado";
            this.Size = new Size(300, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label resultadoLabel = new Label();
            resultadoLabel.Text = resultado;
            resultadoLabel.Location = new Point(20, 20);
            resultadoLabel.Size = new Size(250, 150);
            resultadoLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            resultadoLabel.TextAlign = ContentAlignment.MiddleLeft;

            this.Controls.Add(resultadoLabel);
        }
    }
}