namespace Exemplo1_Winforms_IDE;


partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label label1;
 // Criação de uma tributo com o tipo de uma casse especifica para texto

    private System.Windows.Forms.TextBox textBox1; // Criação de uma tributo com o tipo de uma casse especifica para caixa de texto

    private System.Windows.Forms.Button button1; // Criação de uma tributo com o tipo de uma casse especifica para botão

    private System.Windows.Forms.TextBox textBox2; // Criação de uma tribut

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



    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() // Esse metodo é camado para incializar os componentes
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Calculadora";

        // Iniciar as variaveis criadas
        this.label1 = new System.Windows.Forms.Label();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.button1 = new System.Windows.Forms.Button();
        this.textBox2 = new System.Windows.Forms.TextBox();

        // Configuração do label1
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(30, 30);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(60, 17);
        this.label1.Text = "Digite um numero:";

        // Configuração do textBox1
        this.textBox1.Location = new System.Drawing.Point(140, 27);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(150, 25);

        // Configuração do textBox2
        this.textBox2.Location = new System.Drawing.Point(140, 60);
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(150, 25);

        // Configuração do button1
        this.button1.Location = new System.Drawing.Point(320, 40);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(100, 25);
        this.button1.Text = "Clique aqui";
        this.button1.Click += new System.EventHandler(this.button1_Click); // Adicionar o evento de clique ao botão


        this.Controls.Add(this.label1);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.textBox2);
        this.Controls.Add(this.button1);

        
        
       
    }

    #endregion
}
